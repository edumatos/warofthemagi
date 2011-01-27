using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public class BaseBuilding : BaseObject
    {
        public const float DefaultSize = 32f;

        #region Properties

        public int Cost { get; set; }

        #endregion

        #region Constructors

        public BaseBuilding():base() { Health = MaxHealth = 1000; }

        #endregion

        #region Methods

        public override void GenerateStateMessage(PlayerIO.GameLibrary.Message gamestate)
        {
            gamestate.Add(Owner);
            gamestate.Add(Alive);
            gamestate.Add(Position.X);
            gamestate.Add(Position.Y);
            gamestate.Add(Health);
            gamestate.Add(MaxHealth);
        }

        public override void GetAttackedBy(BaseObject bob)
        {
            if (bob is BaseUnit)
            {
                int damage = 0;
                damage = Math.Min(1, ((BaseUnit)bob).Attack);
                if (damage > 0)
                {
                    Health -= damage;
                    OnDamaged(new DamagedEventArgs(Position, damage));
                }
            }
        }

        #endregion
    }
}
