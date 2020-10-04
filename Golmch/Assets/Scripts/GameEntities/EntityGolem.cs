using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    public class EntityGolem : GameEntity, ITargetable, IDamageable
    {
        public int Health { get; set; }

        public bool IsDown
        {
            get => this.Health <= 0;
        }


        public void ApplyDamage(Damage damage)
        {
            if (IsDown)
                return;

            Health -= Mathf.CeilToInt (damage.amount);

            if (IsDown)
                OnDowned ();
        }

        public void OnDowned()
        {

        }


        public void OnTarget()
        {
            throw new System.NotImplementedException ();
        }
    }
}