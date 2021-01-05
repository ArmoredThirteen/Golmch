﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ATE
{
    [CreateAssetMenu (fileName = "Activated_ApplyDamage_", menuName = "Golmch/Abilities/Activated/ApplyDamage", order = 150)]
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

        public override Ability_Activated GetModified(List<Ability_Modifier> mods)
        {
            //Debug.Log(mods.Count);
            // Get all appropriate mods and cast them
            List<Modifier_ApplyDamage_Amount> castMods =
                mods.FindAll(m => m is Modifier_ApplyDamage_Amount)
                .Cast<Modifier_ApplyDamage_Amount>().ToList();

            Activated_ApplyDamage newAbility = ScriptableObject.Instantiate(this);
            //Debug.Log(castMods.Count);
            newAbility.minAmount = ModMath.Result(newAbility.minAmount, castMods);
            newAbility.maxAmount = ModMath.Result(newAbility.maxAmount, castMods);
            return newAbility;
        }

    }
}