using System;
using PlayerIO.GameLibrary;
using WotMServer.Data;
using System.Collections.Generic;

namespace WotMServer
{
    [RoomType("WotMMatch")]
    public class Match : Game<Wizard>
    {
        #region Properties

        public bool GameRunning { get; set; }

        public bool GameOver { get; set; }

        public float GameStateTimer { get; private set; }

        public float SpawnTimer { get; private set; }

        public float WaveTime { get; set; }

        public int Wave { get; set; }

        BaseUnit NeutralSpawn { get; set; }

        public SortedList<int, Area> Areas { get; set; }

        #endregion

        public Match()
        {
            Areas = new SortedList<int, Area>();
        }

        public override void GameStarted()
        {
            GameRunning = false;
            GameOver = false;
            Wave = 0;
            WaveTime = 120f;

            NeutralSpawn = new BaseUnit();

            AddTimer(Update, 20);
            base.GameStarted();
        }

        public override void GameClosed()
        {
            base.GameClosed();
        }

        public override void UserJoined(Wizard player)
        {
            int maxplayers;
            Areas.Add(player.Id, new Area(player));
            Areas[player.Id].UnitTrained += new TrainedEventHandler(Match_UnitTrained);
            player.ViewPlayerId = player.Id;
            //Parse roomdata
            if (!int.TryParse(RoomData["maxplayers"], out maxplayers))
                maxplayers = 4; //Default
            if (Areas.Count == maxplayers)
                GameRunning = true;
            base.UserJoined(player);
        }

        void Match_UnitTrained(object sender, EventArgs e)
        {
            // make a base unit to attack in all enemy areas
            foreach (KeyValuePair<int, Area> a in Areas)
            {
                if (a.Value != (Area)sender)
                {
                    BaseUnit unit = new BaseUnit();
                    unit.Owner = ((Area)sender).Owner;
                    unit.TargetLocation = new Vector2F(.5f * Area.Size.X, Area.Size.Y);
                    unit.Damaged += new DamagedEventHandler(Match_ObjectDamaged);
                    a.Value.Units.Add(unit);
                }
            }
        }

        void Match_ObjectDamaged(object sender, DamagedEventArgs e)
        {
            Broadcast("Damage", e.ID, e.Damage);
        }

        public override void UserLeft(Wizard player)
        {
            // remove the area belonging to this player
            Areas.Remove(player.Id);

            // set all units belonging to this player to neutral
            foreach (KeyValuePair<int, Area> a in Areas)
                a.Value.RemovePlayerUnits(player);

            base.UserLeft(player);
        }

        public override bool AllowUserJoin(Wizard player)
        {
            int maxplayers; //Default

            if (GameRunning)
            {
                player.Send("Started");
                return false;
            }

            //Parse roomdata
            if (!int.TryParse(RoomData["maxplayers"], out maxplayers))
                maxplayers = 4; //Default

            //Check if there's room for this player.
            if (Areas.Count < maxplayers - 1)
                return true;

            player.Send("Full");
            return false;
        }

        public override void GotMessage(Wizard player, Message message)
        {
            switch (message.Type)
            {
                case "MaxPlayers":
                    int mp = message.GetInt(0);
                    if (mp >= 2)
                        RoomData["maxplayers"] = mp.ToString();
                    break;
                case "WizardJoined":
                    Broadcast("WizardJoined", player.Id, message.GetString(0));
                    break;
                case "WizardSurrender":
                    Broadcast("WizardSurrender", player.Id);
                    Areas.Remove(player.Id);
                    CheckForWinner();
                    break;
                case "Build":
                    Areas[player.Id].AttemptBuild(message);
                    break;
            }
            base.GotMessage(player, message);
        }

        private void CheckForWinner()
        {
            //TODO: declare winner, end game
            if (Areas.Count == 1)
            {
                Areas.Values[0].Owner.Send("Win");
                GameOver = true;
            }
        }

        void Update()
        {
            const float delta = 20f / 1000;

            if (GameRunning && !GameOver)
            {

                //TODO: update wave
                WaveTime -= delta;
                if (Wave == 0)
                {
                    bool allready = true;
                    foreach (Wizard w in Players)
                        if (w.Ready == false)
                            allready = false;
                    if (allready)
                        GotoNextWave();
                }
                if (WaveTime <= 0)
                {
                    GotoNextWave();
                }
                else
                {
                    //spawn some units
                    SpawnTimer += delta;
                    if (SpawnTimer >= .25f)
                    {
                        SpawnTimer -= .25f;
                        SpawnNeutrals();
                    }
                }

                //update players
                foreach (Wizard w in Players)
                    w.Update(delta);

                // update units and buildings
                foreach (KeyValuePair<int, Area> a in Areas)
                    a.Value.Update(delta);

                //TODO: send out gamestate
                GameStateTimer += delta;
                if (GameStateTimer >= .1f)
                {
                    GameStateTimer -= .1f;
                    //TODO: compile data for gamestate
                    foreach (Wizard w in Players)
                    {
                        Message gamestate = Message.Create("State");
                        Areas[w.ViewPlayerId].GenerateStateMessage(gamestate);
                        w.Send(gamestate);
                    }
                }
            }
        }

        private void SpawnNeutrals()
        {
            //spawn neutrals
            foreach (KeyValuePair<int, Area> a in Areas)
            {
                Random rand = new Random();
                BaseUnit neutral = NeutralSpawn.MakeCopy();
                neutral.Position = new Vector2F(Convert.ToSingle(rand.NextDouble()) * Area.Size.X, 0);
                neutral.TargetLocation = new Vector2F(.5f * Area.Size.X, Area.Size.Y - 1);
                neutral.Orders = BaseUnit.Actions.ATTACK;
                a.Value.Neutrals.Add(neutral);
                neutral.Damaged += new DamagedEventHandler(Match_ObjectDamaged);
            }
        }

        void GotoNextWave()
        {
            Wave++;
            WaveTime = 30f;
            //setup some params for neutral units for this wave
            NeutralSpawn.Attack = Wave;
            NeutralSpawn.Health = NeutralSpawn.MaxHealth = 8 + (Wave << 1);
            NeutralSpawn.Defense = Wave;
            NeutralSpawn.Speed = 50f + Wave;
            NeutralSpawn.Reward = Wave;
        }

    }
}
