using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    public abstract class Ability_Activated : Ability
	{
        public abstract void Activate(GameEntity source, params GameEntity[] targets);
		
	}
}