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

        public int Reward { get; set; }

        public int Attack { get; set; }

        public float AttackSpeed { get; set; }

        public float AttackTimer { get; private set; }

        public int Defense { get; set; }

        public int MagicDefense { get; set; }

        public float Speed { get; set; }

        public Vector2F Velocity { get; private set; }

        public Actions Orders { get; set; }

        public BaseObject TargetObject { get; set; }

        public Vector2F TargetLocation { get; set; }

        #endregion

        #region Events
        //
        #endregion

        #region Constructors

        public BaseUnit()
            : base()
        {
            TargetLocation = Vector2F.Invalid;
            AttackSpeed = 1f;
            AttackTimer = 1f;
            Speed = 50f;
            Health = MaxHealth = 20;
            Defense = 10;
            Attack = 10;
        }

        #endregion

        #region Methods

        public BaseUnit MakeCopy()
        {
            BaseUnit copy = (BaseUnit)this.MemberwiseClone();
            copy.ID = GenerateUniqueID();
            return copy;
        }

        public override void Update(float delta)
        {
            // move unit
            Position += Velocity * delta;

            // calculate next orders
            switch (Orders)
            {
                case Actions.ATTACK:
                    //TODO: move unit and/or attack
                    if (TargetObject != null)
                    {
                        if (TargetObject.Alive)
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
                                AttackTimer += delta;
                                if (AttackTimer >= AttackSpeed)
                                {
                                    AttackTimer -= AttackSpeed;
                                    TargetObject.GetAttackedBy(this);
                                }
                            }
                        }
                        else
                        {
                            Velocity = Vector2F.Empty;
                            TargetObject = null;
                        }

                    }
                    else if (TargetLocation.isValid())
                    {
                        Vector2F direction = TargetObject.Position - Position;
                        if (direction.MagnitudeSquared() > 25f)
                        {
                            direction.Normalize();
                            direction *= Speed;
                            Velocity = direction;
                        }
                    }
                    break;
                case Actions.MOVE:
                    if (TargetObject != null)
                    {
                        if (TargetObject.Alive)
                        {
                            Vector2F direction = TargetObject.Position - Position;
                            if (direction.MagnitudeSquared() > 25f)
                            {
                                direction.Normalize();
                                direction *= Speed;
                                Velocity = direction;
                            }
                        }
                        else
                        {
                            Velocity = Vector2F.Empty;
                            TargetObject = null;
                        }
                    }
                    else if (TargetLocation.isValid())
                    {
                        Vector2F direction = TargetObject.Position - Position;
                        if (direction.MagnitudeSquared() > 25f)
                        {
                            direction.Normalize();
                            direction *= Speed;
                            Velocity = direction;
                        }
                        else
                        {
                            Orders = Actions.STOP;
                            Velocity = Vector2F.Empty;
                            TargetLocation = Vector2F.Invalid;
                        }
                    }
                    break;
                case Actions.PATROL:
                    // possible feature
                    break;
            }

            base.Update(delta);
        }

        public override void GetAttackedBy(BaseObject bob)
        {
            int damage = 0;
            if (bob is BaseUnit)
            {
                damage = Math.Min(1, ((BaseUnit)bob).Attack - Defense);
            }
            else if (bob is Tower)
            {
                damage = Math.Min(1, ((Tower)bob).Attack - Defense);
            }
            if (damage > 0)
            {
                Health -= damage;
                OnDamaged(new DamagedEventArgs(ID, damage));
            }
        }

        public override void GenerateStateMessage(PlayerIO.GameLibrary.Message gamestate)
        {
            gamestate.Add(ID);
            gamestate.Add(Owner);
            gamestate.Add(Alive);
            gamestate.Add(Position.X);
            gamestate.Add(Position.Y);
            gamestate.Add(Health);
            gamestate.Add(MaxHealth);
        }

        #endregion
    }
}
