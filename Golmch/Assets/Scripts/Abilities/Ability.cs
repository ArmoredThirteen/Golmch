using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ATE
{
	public abstract class Ability : ScriptableObject
	{
		public string displayName = "DEFAULT";

        public List<ModdingAbilityType> moddingAbilityTypes = new List<ModdingAbilityType>();


        // Returns true if any moddingAbilityTypes match between this Ability and the given Ability
        public bool HasMatchingModTypes(Ability from)
        {
            return moddingAbilityTypes.Intersect(from.moddingAbilityTypes).Any();

            /*for (int i = 0; i < moddingAbilityTypes.Count; i++)
                if (from.moddingAbilityTypes.Contains(moddingAbilityTypes[i]))
                    return true;

            return false;*/
        }
    }
}