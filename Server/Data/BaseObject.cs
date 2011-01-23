using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public abstract class BaseObject
    {
        #region Properties

        public string Name { get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        #endregion

        #region Interface

        public abstract void Update(float delta);

        #endregion
    }
}
