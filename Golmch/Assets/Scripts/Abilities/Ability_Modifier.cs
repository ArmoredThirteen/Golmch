using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    [CreateAssetMenu (fileName = "AbilityModifier_", menuName = "Golems/Abilities/Modifier", order = 150)]
	public abstract class Ability_Modifier : Ability
	{
        public int modPriority = 0;

        /*public virtual void ApplyMod(GameEntity source, params GameEntity[] targets)
        {

        }*/
		
	}
}