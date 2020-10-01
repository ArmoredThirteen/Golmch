using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    [CreateAssetMenu (fileName = "Activated_ApplyDamage_", menuName = "Golems/Abilities/Activated/ApplyDamage", order = 150)]
	public class Activated_ApplyDamage : Ability_Activated
	{
        public DamageType type;
        public float minAmount;
        public float maxAmount;


        public Damage RollDamage()
        {
            Damage damage = new Damage (type);
            damage.amount = Random.Range (minAmount, maxAmount);
            return damage;
        }
        

        public override void Activate(GameEntity source, params GameEntity[] targets)
        {
            if (targets == null)
                return;

            for (int i = 0; i < targets.Length; i++)
            {
                if (!(targets[i] is IDamageable))
                    continue;

                IDamageable damageable = (IDamageable)targets[i];
                damageable.ApplyDamage (RollDamage ());
            }
        }

    }
}