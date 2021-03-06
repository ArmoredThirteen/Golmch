﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    [CreateAssetMenu (fileName = "Frame_", menuName = "Golmch/Frame", order = 150)]
	public class FrameSettings : ScriptableObject
	{
        public string displayName = "DEFAULT";

        public int startHealth = 50;
        public int startMana = 100;

        public float volume = 10;
        public float volumePerArmor = 0.5f;

        public float manaPerMovePerWeight = 0.1f;

        public CompartmentSettings[] compartments;


        public override string ToString()
        {
            string str = "";

            str += "Display Name: " + displayName
            + "\nStart Health: " + startHealth
            + "\nStart Mana: " + startMana
            + "\nVolume: " + volume
            + "\nVolume per Armor: " + volumePerArmor
            + "\nMana per Move per Weight: " + manaPerMovePerWeight;

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