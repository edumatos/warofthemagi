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

        public string Name { get; set; }

        public int Win { get; set; }

        public int Loss { get; set; }

        public int ViewPlayerId { get; set; }

        public int Mana { get; set; }

        public int Research { get; set; }

        public ElementType Element { get; set; }

        public List<Spell> Spells { get; set; }

        #endregion

        #region Constructors

        public Wizard()
        {
            Spells = new List<Spell>();
            Element = ElementType.NONE;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Update wizard's stats.
        /// </summary>
        /// <param name="delta">time elasped since last update</param>
        public void Update(float delta)
        {
            //TODO: update stats.
        }

        #endregion
    }
}
