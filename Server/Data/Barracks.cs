using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public delegate void TrainedEventHandler(object sender, EventArgs e);

    public class Barracks : BaseBuilding
    {
        public event TrainedEventHandler Trained;

        #region Properties

        public float TrainningRate { get; set; }

        public float TrainningTimer { get; private set; }

        #endregion

        #region Constructors

        public Barracks(Wizard owner)
        {
            Owner = owner;
            Health = MaxHealth = 200;
            TrainningRate = 1f;
            Cost = 150;
        }

        #endregion

        #region Methods

        public override void Update(float delta)
        {
            TrainningTimer += delta;
            if (TrainningTimer >= TrainningRate)
            {
                TrainningTimer -= TrainningRate;
                if (Trained != null)
                    Trained(this, new EventArgs());
            }
            base.Update(delta);
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
                    OnDamaged(new DamagedEventArgs(ID, damage));
                }
            }
        }

        public override void GenerateStateMessage(PlayerIO.GameLibrary.Message gamestate)
        {
            gamestate.Add(ID);
            gamestate.Add(Owner);
            gamestate.Add(Alive);
            gamestate.Add(Health);
            gamestate.Add(MaxHealth);
        }

        #endregion
    }
}
