using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    public abstract class Ability_Activated : Ability
	{
        public TargetingType targetingType = TargetingType.Entity;
        public float maxTargetDistance = 1;
        public AreaType areaType = AreaType.Single;

        public float manaCost = 5;


        public abstract void Activate(GameEntity source, params GameEntity[] targets);

        public abstract Ability_Activated GetModified(List<Ability_Modifier> mods);
		
	}
}