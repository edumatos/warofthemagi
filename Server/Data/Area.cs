using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public class Area
    {
        public static readonly Vector2F Size = new Vector2F(384, 480);

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
                b.Update(delta);
            foreach (BaseUnit bu in Units)
                bu.Update(delta);
            foreach (BaseUnit bu in Neutrals)
                bu.Update(delta);
        }

        public void RemovePlayerUnits(Wizard wizard)
        {
            for (int i = 0; i < Units.Count;)
            {
                if (Units[i].Owner == wizard)
                    Units.RemoveAt(i);
                else ++i;

            }
        }

        #endregion

    }
}
