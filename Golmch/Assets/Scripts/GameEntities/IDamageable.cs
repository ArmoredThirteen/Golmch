using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
	public interface IDamageable
	{
        int Health { get; set; }
        bool IsDown { get; }

        void ApplyDamage(Damage damage);
        void OnDowned();
		
	}
}