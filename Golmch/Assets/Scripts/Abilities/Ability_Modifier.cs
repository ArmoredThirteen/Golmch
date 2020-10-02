using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    public abstract class Ability_Modifier : Ability
	{
        // If true, only applies to gears within the same compartment
        // If false, applies to all gears within the golem
        public bool compartmentOnly = true;

        public List<GearType> allowedGearTypes = new List<GearType> ();
	}
}