using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public abstract class BaseObject
    {
        #region Properties

        public Wizard Owner { get; set; }

        public string Name { get; set; }

        public Vector2F Position { get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public float Range { get; set; }

        #endregion

        #region Interface

        public abstract void Update(float delta);

        public abstract void GetAttackedBy(BaseObject bo);

        #endregion

    }
}
