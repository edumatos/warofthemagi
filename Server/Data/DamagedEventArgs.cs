using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public class DamagedEventArgs : EventArgs
    {
        #region Properties

        public Vector2F Position { get; set; }

        public int Damage { get; set; }

        #endregion

        #region Constructors

        public DamagedEventArgs(Vector2F position, int damage)
        {
            Position = position;
            Damage = damage;
        }

        #endregion
    }
}
