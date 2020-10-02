using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    [CreateAssetMenu (fileName = "Compartment_", menuName = "Golmch/Compartment", order = 150)]
	public class CompartmentSettings : ScriptableObject
	{
        public string displayName = "DEFAULT";
		public CompartmentType compartmentType = CompartmentType.Cavity;

        public int slots = 1;


        public override string ToString()
        {
            string str = "";

            str += "Display Name: " + displayName;
            str += "\nCompartment Type: " + compartmentType;
            str += "\nSlots: " + slots;

            return str;
        }
	}
}