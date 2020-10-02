using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    [CreateAssetMenu (fileName = "Medium_", menuName = "Golmch/Medium", order = 150)]
    public class MediumSettings : ScriptableObject
    {
        public string displayName = "DEFAULT";
        public float density = 1;


        public override string ToString()
        {
            string str = "";

            str += "Display Name: " + displayName;
            str += "\nDensity: " + density;

            return str;
        }
    }
}
