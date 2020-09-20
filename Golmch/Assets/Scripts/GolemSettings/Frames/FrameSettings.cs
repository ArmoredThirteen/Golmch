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


        public override string ToString()
        {
            string str = "";

            str += "Display Name: " + displayName;
            str += "\nVolume: " + volume;

            for (int i = 0; i < compartments.Length; i++)
            {
                str += "\nCompartment: " + compartments[i].name;

                string[] splitStr = compartments[i].ToString ().Split ('\n');
                for (int k = 0; k < splitStr.Length; k++)
                    str += "\n    " + splitStr[k];
            }

            return str;
        }
    }
}