using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
	public interface IDamageable
	{
        int MaxHealth { get; }
        int Health { get; }
        int Armor { get; }

        bool IsDown { get; }

        void ApplyDamage(Damage damage);
        void OnDowned();
		
	}
}