using PlayerIO.GameLibrary;
using System.Collections.Generic;

namespace WotMServer.Data
{
    public class Wizard : BasePlayer
    {
        public enum ElementType
        {
            NONE                = 0,
            FIRE                = 1,
            EARTH               = 2,
            WIND                = 3,
            WATER               = 4,
            LIGHTNING           = 5,
            CAPTAIN_PLANET      = 6
        }

        #region Properties

        public bool Ready { get; set; }

        public int ViewPlayerId { get; set; }

        public int Mana { get; set; }

        public ElementType Element { get; set; }

        public List<BaseBuilding> Buildings { get; set; }

        public List<BaseUnit> Units { get; set; }

        public List<BaseUnit> Neutrals { get; set; }

        public List<Spell> Spells { get; set; }

        #endregion

        #region Constructors

        public Wizard()
        {
            Buildings = new List<BaseBuilding>();
            Units = new List<BaseUnit>();
            Neutrals = new List<BaseUnit>();
            Spells = new List<Spell>();
            Element = ElementType.NONE;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Update wizard's objects.
        /// </summary>
        /// <param name="delta">time elasped since last update</param>
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

        #endregion
    }
}
