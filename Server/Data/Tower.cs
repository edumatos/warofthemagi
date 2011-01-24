using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    public class Tower : BaseBuilding
    {
        public enum AttackType
        {
            PHYSICAL = 0,
            NONE = 0,
            MAGICAL = 1,
            ELEMENT = 1
        }

        public enum StatusType
        {
            NONE = 0,
            SLOW,
            STOP,
            DRAIN
        }

        #region Fields

        int baseAttack, baseRegeneration;
        float baseReloadTime;

        float regenerationTick, coolingTime;

        #endregion

        #region Properties

        public new int MaxHealth
        {
            get { return (int)(base.MaxHealth * MaxHealthBonus); }
            set { base.MaxHealth = value; }
        }

        public int Attack
        {
            get { return (int)(baseAttack * AttackBonus); }
            set { baseAttack = value; }
        }

        public float ReloadTime
        { 
            get { return baseReloadTime * (1 / FiringRateBonus); }
            set { baseReloadTime = value; } 
        }

        public new float Range
        {
            get { return base.Range * RangeBonus; }
            set { base.Range = value; }
        }

        public int Regeneration
        {
            get { return (int)(baseRegeneration * RegenerationBonus); }
            set { baseRegeneration = value; }
        }

        public AttackType Type { get; set; }

        public StatusType Status { get; set; }

        #region Upgrade multipliers
        public float MaxHealthBonus { get; set; }
        public float AttackBonus { get; set; }
        public float FiringRateBonus { get; set; }
        public float RangeBonus { get; set; }
        public float RegenerationBonus { get; set; }
        #endregion

        public bool ReadyToFire { get; private set; }

        public BaseObject TargetObject { get; set; }

        #endregion

        #region Constructors

        Tower() { }

        public Tower(Wizard owner)
        {
            Cost = 50;
            Health = 100;
            MaxHealth = 100;
            Attack = 10;
            Range = 100;
            ReloadTime = 1f;
            Type = AttackType.NONE;
            Status = StatusType.NONE;
            Owner = owner;
            MaxHealthBonus = AttackBonus = FiringRateBonus = RangeBonus = RegenerationBonus = 1f;
            regenerationTick = coolingTime = 0f;
            ReadyToFire = true;
        }

        #endregion

        #region Methods

        public override void Update(float delta)
        {
            if (!ReadyToFire)
            {
                coolingTime += delta;
                if (coolingTime >= ReloadTime)
                {
                    coolingTime -= ReloadTime;
                    ReadyToFire = true;
                }
            }
            if (Health < MaxHealth)
            {
                regenerationTick += delta * Regeneration;
                Health += Convert.ToInt32(Math.Floor(regenerationTick));
                regenerationTick -= Convert.ToSingle(Math.Floor(regenerationTick));
                if (Health > MaxHealth)
                    Health = MaxHealth;
            }
        }

        #endregion
    }
}
