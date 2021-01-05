using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    public abstract class Ability_Modifier_Number : Ability_Modifier
	{
        public ModMathType modType = ModMathType.Add_PreMult;
        public float modAmount = 0;
	}
}