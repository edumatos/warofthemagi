using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerIO.GameLibrary;

namespace WotMServer.Data
{
    public class Area
    {
        public event TrainedEventHandler UnitTrained;

        public const float Width = 384f;

        public const float Height = 480f;

        public enum BuildingTypes
        {
            BASE = 0,
            TOWER = 1,
            BARRACKS = 2
        }

        #region Properties

        public Wizard Owner { get; set; }

        public List<BaseBuilding> Buildings { get; set; }

        public List<BaseUnit> Units { get; set; }

        public List<BaseUnit> Neutrals { get; set; }
        
        #endregion

        #region Constructors

        Area()
        {
            Buildings = new List<BaseBuilding>();
            Units = new List<BaseUnit>();
            Neutrals = new List<BaseUnit>();
            Owner = null;
        }

        public Area(Wizard owner)
        {
            Buildings = new List<BaseBuilding>();
            Units = new List<BaseUnit>();
            Neutrals = new List<BaseUnit>();
            Owner = owner;
        }

        #endregion

        #region Methods

        public void Update(float delta)
        {
            // update all the objects
            foreach (BaseBuilding b in Buildings)
            {
                b.Update(delta);
                if (b is Tower)
                {
                    Tower t = (Tower)b;
                    if (t.TargetObject == null)
                        t.TargetObject = GetClosestEnemyObjectInVisibleRangeOf(t);
                }
            }
            foreach (BaseUnit bu in Units)
            {
                bu.Update(delta);
                if (bu.Orders == BaseUnit.Actions.STOP || bu.Orders == BaseUnit.Actions.ATTACK)
                    if (bu.TargetObject == null)
                    {
                        bu.TargetObject = GetClosestEnemyObjectInVisibleRangeOf(bu);
                        bu.Orders = BaseUnit.Actions.ATTACK;
                    }
            }
            foreach (BaseUnit bu in Neutrals)
            {
                bu.Update(delta);
                if (bu.Orders == BaseUnit.Actions.STOP || bu.Orders == BaseUnit.Actions.ATTACK)
                    if (bu.TargetObject == null)
                    {
                        bu.TargetObject = GetClosestEnemyObjectInVisibleRangeOf(bu);
                        bu.Orders = BaseUnit.Actions.ATTACK;
                    }
            }

            // clean up the corpses
            RemoveDeadOnes();
        }

        private void RemoveDeadOnes()
        {
            for (int i = 0; i < Buildings.Count; )
                if (!Buildings[i].Alive)
                    Buildings.RemoveAt(i);
                else ++i;
            for (int i = 0; i < Units.Count; )
                if (!Units[i].Alive)
                    Units.RemoveAt(i);
                else ++i;
            for (int i = 0; i < Neutrals.Count; )
                if (!Neutrals[i].Alive)
                {
                    Owner.Mana += Neutrals[i].Reward;
                    Owner.Send("KilledNeutral", Neutrals[i].Reward, Owner.Mana);
                    Neutrals.RemoveAt(i);
                }
                else ++i;
        }

        public void RemovePlayerUnits(Wizard wizard)
        {
            for (int i = 0; i < Units.Count;)
            {
                if (Units[i].Owner == wizard)
                {
                    Units[i].Owner = null;
                    Neutrals.Add(Units[i]);
                    Units.RemoveAt(i);
                }
                else ++i;

            }
        }

        public BaseObject GetClosestEnemyObjectInVisibleRangeOf(BaseObject bob)
        {
            BaseObject retval = null;
            float closestDistanceSquared = 480 * 480;
            if (bob is BaseUnit) // towers shouldn't bother with other buildings since they will always be on the same team
            {
                if (bob.Owner != Owner) // only bother with buildings if this isn't bo's owner's area
                    foreach (BaseBuilding b in Buildings)
                    {
                        Vector2F distance = b.Position - bob.Position;
                        if (distance.MagnitudeSquared() < (BaseObject.VisibleRange * BaseObject.VisibleRange) &&
                            distance.MagnitudeSquared() < closestDistanceSquared)
                        {
                            closestDistanceSquared = distance.MagnitudeSquared();
                            retval = b;
                        }
                    }
            }
            foreach (BaseUnit bu in Units)
            {
                if (bu.Owner != bob.Owner) // don't bother with units that are on the same team
                {
                    Vector2F distance = bu.Position - bob.Position;
                    if (distance.MagnitudeSquared() < (BaseObject.VisibleRange * BaseObject.VisibleRange) &&
                        distance.MagnitudeSquared() < closestDistanceSquared)
                    {
                        closestDistanceSquared = distance.MagnitudeSquared();
                        retval = bu;
                    }
                }
            }
            foreach (BaseUnit bu in Neutrals)
            {
                if (bob.Owner == Owner) // don't bother with neutrals unless this is bo's owner's area
                {
                    Vector2F distance = bu.Position - bob.Position;
                    if (distance.MagnitudeSquared() < (BaseObject.VisibleRange * BaseObject.VisibleRange) &&
                        distance.MagnitudeSquared() < closestDistanceSquared)
                    {
                        closestDistanceSquared = distance.MagnitudeSquared();
                        retval = bu;
                    }
                }
            }
            return retval;
        }

        #endregion


        internal void GenerateStateMessage(PlayerIO.GameLibrary.Message gamestate)
        {
            gamestate.Add(Buildings.Count);
            foreach (BaseBuilding b in Buildings)
            {
                if (b is Tower)
                {
                    gamestate.Add((int)BuildingTypes.TOWER);
                    b.GenerateStateMessage(gamestate);
                }
                else if (b is Barracks)
                {
                    gamestate.Add((int)BuildingTypes.BARRACKS);
                    b.GenerateStateMessage(gamestate);
                }
                else
                {
                    // must be wizard base
                    gamestate.Add((int)BuildingTypes.BASE);
                    b.GenerateStateMessage(gamestate);
                }
            }
        }

        internal void AttemptBuild(PlayerIO.GameLibrary.Message message)
        {
            Vector2F location = Vector2F.Empty();
            Message m;
            switch (message.GetInt(0))
            {
                case (int)BuildingTypes.TOWER:
                    location = new Vector2F(message.GetFloat(1), message.GetFloat(2));
                    if (location.Y < 120f || location.Y + Tower.DefaultSize >= Height ||
                        location.X < 0 || location.X + Tower.DefaultSize >= Width ||
                        Owner.Mana < 50)
                    {
                        Owner.Send("Build", false);
                        return;
                    }
                    foreach (BaseBuilding b in Buildings)
                    {
                        if (b.Intersects(location, new Vector2F(Tower.DefaultSize, Tower.DefaultSize)))
                        {
                            Owner.Send("Build", false);
                            return;
                        }
                    }
                    Tower newTower = new Tower(Owner);
                    newTower.Position = location;
                    Buildings.Add(newTower);
                    Owner.Mana -= newTower.Cost;
                    m = Message.Create("Build", true, newTower.Cost, Owner.Mana);
                    newTower.GenerateStateMessage(m);
                    m.Add(Tower.DefaultSize, Tower.DefaultSize);
                    Owner.Send(m);
                    break;
                case (int)BuildingTypes.BARRACKS:
                    location = new Vector2F(message.GetFloat(1), message.GetFloat(2));
                    if (location.Y < 120f || location.Y + Barracks.DefaultSize >= Height ||
                        location.X < 0 || location.X + Barracks.DefaultSize >= Width ||
                        Owner.Mana < 50)
                    {
                        Owner.Send("Build", false);
                        return;
                    }
                    foreach (BaseBuilding b in Buildings)
                    {
                        if (b.Intersects(location, new Vector2F(Barracks.DefaultSize, Barracks.DefaultSize)))
                        {
                            Owner.Send("Build", false);
                            return;
                        }
                    }
                    Barracks newBarracks = new Barracks(Owner);
                    newBarracks.Position = location;
                    Buildings.Add(newBarracks);
                    Owner.Mana -= newBarracks.Cost;
                    m = Message.Create("Build", true, newBarracks.Cost, Owner.Mana);
                    newBarracks.GenerateStateMessage(m);
                    m.Add(Barracks.DefaultSize, Barracks.DefaultSize);
                    Owner.Send(m);
                    newBarracks.Trained += new TrainedEventHandler(newBarracks_Trained);
                    break;
            }
        }

        void newBarracks_Trained(object sender, EventArgs e)
        {
            if (UnitTrained != null)
                UnitTrained(this, e);
        }
    }
}
