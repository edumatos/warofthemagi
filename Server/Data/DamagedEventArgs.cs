using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public class DamagedEventArgs : EventArgs
    {
        #region Properties

        public int ID { get; set; }

        public int Damage { get; set; }

        #endregion

        #region Constructors

        public DamagedEventArgs(int id, int damage)
        {
            ID = id;
            Damage = damage;
        }

        #endregion
    }
}
