using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public class BaseBuilding : BaseObject
    {
        public static readonly Vector2F DefaultSize = new Vector2F(32, 32);

        #region Properties

        public int Cost { get; set; }

        #endregion

        #region Constructors

        public BaseBuilding():base() { Health = MaxHealth = 1000; }

        #endregion

        #region Methods

        public override void GenerateStateMessage(PlayerIO.GameLibrary.Message gamestate)
        {
            gamestate.Add(ID);
            gamestate.Add(Owner);
            gamestate.Add(Alive);
            gamestate.Add(Health);
            gamestate.Add(MaxHealth);
        }

        public override void GetAttackedBy(BaseObject bob)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
