using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ATE
{
	public class ModMath
	{
        public static float Result<T>(float value, List<T> mods) where T : Ability_Modifier_Number
        {
            // For all mods of a given type, make a list of the containing mod amounts
            List<float> addPreMults =   GetModsValues<T> (mods, ModMathType.Add_PreMult);
            List<float> addPostMults =  GetModsValues<T> (mods, ModMathType.Add_PostMult);
            List<float> multAddeds =    GetModsValues<T> (mods, ModMathType.Mult_Added);
            List<float> multCompounds = GetModsValues<T> (mods, ModMathType.Mult_Compound);

            return Result (value, addPreMults, addPostMults, multAddeds, multCompounds);
        }

        public static float Result(float value, List<float> addPreMults, List<float> addPostMults, List<float> multAddeds, List<float> multCompounds)
        {
            return ((value + Summed (addPreMults, 0)) * Summed (multAddeds, 1) * Multiplied (multCompounds, 1)) + Summed (addPostMults, 0);
        }


        public static float Summed(List<float> values, float defaultValue)
        {
            float value = defaultValue;
            if (values == null)
                return value;
            if (values.Count <= 0)
                return value;

            for (int i = 0; i < values.Count; i++)
                value += values[i];
            return value;
        }

        public static float Multiplied(List<float> values, float defaultValue)
        {
            float value = defaultValue;
            if (values == null)
                return value;
            if (values.Count <= 0)
                return value;

            for (int i = 0; i < values.Count; i++)
                value *= values[i];
            return value;
        }


        private static List<float> GetModsValues<T>(List<T> mods, ModMathType modType) where T : Ability_Modifier_Number
        {
            return mods.FindAll (mod => mod.modType == modType).Select (mod => mod.modAmount).ToList ();
        }
		
	}
}