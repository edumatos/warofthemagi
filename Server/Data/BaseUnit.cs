using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public abstract class BaseUnit : BaseObject
    {
        #region Properties

        public int Attack { get; set; }

        public int Defense { get; set; }

        #endregion

        #region Interface

        //TODO: add methods

        #endregion
    }
}
