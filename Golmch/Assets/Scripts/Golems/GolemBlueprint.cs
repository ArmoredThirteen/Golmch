using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
	public class GolemBlueprint : MonoBehaviour
	{
        public FrameSettings frame;
        public MediumSettings medium;
		
        public float Weight
        {
            get
            {
                return frame.volume * medium.density;
            }
        }
	}
}