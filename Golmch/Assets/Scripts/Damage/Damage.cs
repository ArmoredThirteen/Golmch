using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
	public class Damage
	{
        public DamageType type;
        public float amount;


        public Damage(DamageType theType)
        {
            type = theType;
        }

	}
}