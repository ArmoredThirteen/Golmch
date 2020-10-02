using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    [CreateAssetMenu (fileName = "Modifier_ApplyDamage_Amount_", menuName = "Golmch/Abilities/Modifier/ApplyDamage_Amount", order = 150)]
	public class Modifier_ApplyDamage_Amount : Ability_Modifier
	{
        public List<DamageType> allowedDamageTypes = new List<DamageType> ();

        public ModMathType modType = ModMathType.Add_PreMult;
        public float modAmount = 0;
	}
}