using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    [CreateAssetMenu (fileName = "Gear_", menuName = "Golmch/Gear", order = 150)]
	public class GearSettings : ScriptableObject
	{
        public string displayName = "DEFAULT";

        public List<CompartmentType> allowedCompartments = new List<CompartmentType> ();

        public float weight = 100;
        public int slots = 1;

        public List<Ability> abilities = new List<Ability> ();


        public override string ToString()
        {
            string str = "";

            str += "Display Name: " + displayName;
            str += "\nWeight: " + weight;
            str += "\nSlots: " + slots;

            return str;
        }
	}
}