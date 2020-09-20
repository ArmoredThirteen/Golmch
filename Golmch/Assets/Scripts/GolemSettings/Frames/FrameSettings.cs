using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    [CreateAssetMenu (fileName = "Frame_", menuName = "Golems/Frame", order = 150)]
	public class FrameSettings : ScriptableObject
	{
        public string displayName = "DEFAULT";
        public float volume = 10;
        public CompartmentSettings[] compartments;
	}
}