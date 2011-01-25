using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public delegate void DamagedEventHandler(object sender, DamagedEventArgs e);

    public abstract class BaseObject
    {
        public event DamagedEventHandler Damaged;

        public static readonly float VisibleRange = 100f;

        static int counter = 0;

        #region Properties

        public int ID { get; set; }

        public Wizard Owner { get; set; }

        public bool Alive { get; set; }

        public string Name { get; set; }

        public Vector2F Position { get; set; }

        public Vector2F Dimensions { get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public float Range { get; set; }

        #endregion

        #region Constructors

        public BaseObject()
        {
            ID = GenerateUniqueID();
            Alive = true;
        }

        #endregion

        #region Interface

        public abstract void GetAttackedBy(BaseObject bob);

        public abstract void GenerateStateMessage(PlayerIO.GameLibrary.Message gamestate);

        #endregion

        #region Methods

        public static int GenerateUniqueID()
        {
            return counter++;
        }

        public virtual void Update(float delta)
        {
            if (Health <= 0)
                Alive = false;
        }

        protected virtual void OnDamaged(DamagedEventArgs e)
        {
            if (Damaged != null)
                Damaged(this, e);
        }

        public virtual bool Intersects(BaseObject bob)
        {
            if (Position.X + Dimensions.X < bob.Position.X ||
                Position.Y + Dimensions.Y < bob.Position.Y ||
                Position.X > bob.Position.X + bob.Dimensions.X ||
                Position.Y > bob.Position.Y + bob.Dimensions.Y)
                return false;
            return true;
        }

        public virtual bool Intersects(Vector2F location, Vector2F size)
        {
            if (Position.X + Dimensions.X < location.X ||
                Position.Y + Dimensions.Y < location.Y ||
                Position.X > location.X + size.X ||
                Position.Y > location.Y + size.Y)
                return false;
            return true;
        }

        #endregion

    }
}
