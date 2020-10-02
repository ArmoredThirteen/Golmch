using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
	public class ModMath
	{
        public static float Result(float value, List<float> addPreMults, List<float> addPostMults, List<float> multAddeds, List<float> multCompounds)
        {
            return ((value + Summed (addPreMults)) * Summed (multAddeds) * Multiplied (multCompounds)) + Summed (addPostMults);
        }

        public static float Summed(List<float> values)
        {
            float value = 0;
            if (values == null)
                return value;

            for (int i = 0; i < values.Count; i++)
                value += values[i];
            return value;
        }

        public static float Multiplied(List<float> values)
        {
            float value = 1;
            if (values == null)
                return value;

            for (int i = 0; i < values.Count; i++)
                value *= values[i];
            return value;
        }
		
	}
}