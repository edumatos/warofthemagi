using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public class BaseUnit : BaseObject
    {
        public enum Actions
        {
            NONE = 0,
            STOP = 0,
            MOVE,
            ATTACK,
            PATROL
        }

        #region Properties

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int MagicDefense { get; set; }

        public float Speed { get; set; }

        public Vector2F Velocity { get; private set; }

        public Actions Orders { get; set; }

        public BaseObject TargetObject { get; set; }

        public Vector2F TargetLocation { get; set; }

        #endregion

        #region Constructors

        public BaseUnit():base()
        {
            TargetLocation = Vector2F.Invalid;
        }

        #endregion

        #region Methods

        public override void Update(float delta)
        {
            // perform orders
            switch (Orders)
            {
                case Actions.ATTACK:
                    //TODO: move unit and/or attack
                    if (TargetObject != null)
                    {
                        Vector2F direction = TargetObject.Position - Position;
                        if (direction.MagnitudeSquared() > Range * Range)
                        {
                            direction.Normalize();
                            direction *= Speed;
                            Velocity = direction;
                        }
                        else
                        {
                            TargetObject.GetAttackedBy(this);
                        }
                    }
                    else if (TargetLocation.isValid())
                    {
                    }
                    break;
                case Actions.MOVE:
                    //TODO: move unit
                    break;
                case Actions.PATROL:
                    // possible feature
                    break;
            }
        }

        #endregion
    }
}
