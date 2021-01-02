using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
	public class AbilityMap
	{
        // List of compartments with lists of gears with lists of abilities
        private List<List<List<Ability>>> map;


		public AbilityMap(GolemBlueprint blueprint)
        {
            map = new List<List<List<Ability>>>();

            for (int c = 0; c < blueprint.compartments.Count; c++)
            {
                map.Add(new List<List<Ability>>());
                for (int g = 0; g < blueprint.compartments[c].gears.Count; g++)
                {
                    map[c].Add(new List<Ability>());
                    map[c][g].AddRange(blueprint.compartments[c].gears[g].abilities);
                }
            }
        }


        public List<Ability> GetAbilities_Golem()
        {
            List<Ability> abilities = new List<Ability>();

            for (int c = 0; c < map.Count; c++)
                for (int g = 0; g < map[c].Count; g++)
                    abilities.AddRange(map[c][g]);

            return abilities;
        }

        public List<Ability> GetAbilities_Compartment(int compIndex)
        {
            List<Ability> abilities = new List<Ability>();

            for (int g = 0; g < map[compIndex].Count; g++)
                abilities.AddRange(map[compIndex][g]);

            return abilities;
        }

        public List<Ability> GetAbilities_Gear(int compIndex, int gearIndex)
        {
            List<Ability> abilities = new List<Ability>();

            abilities.AddRange(map[compIndex][gearIndex]);

            return abilities;
        }


        //TODO: This is a bit of a logic abomination with lots of repeat code
        public List<Ability_Activated> GetModifiedActivatedAbilities()
        {
            List<Ability_Activated> returnVal = new List<Ability_Activated>();

            // Get golem mods
            List<Ability> golemAbilities = GetAbilities_Golem();
            List<Ability_Modifier> golemMods = new List<Ability_Modifier>();

            for (int i = 0; i < golemAbilities.Count; i++)
            {
                Ability_Modifier mod = golemAbilities[i] as Ability_Modifier;
                if (mod != null && mod.extent == ModExtent.Golem)
                    golemMods.Add(mod);
            }

            // Each compartment
            for (int c = 0; c < map.Count; c++)
            {
                // Get compartment mods
                List<Ability> compartmentAbilities = GetAbilities_Compartment(c);
                List<Ability_Modifier> compartmentMods = new List<Ability_Modifier>();

                for (int i = 0; i < compartmentAbilities.Count; i++) {
                    Ability_Modifier mod = compartmentAbilities[i] as Ability_Modifier;
                    if (mod != null && mod.extent == ModExtent.Compartment)
                        compartmentMods.Add(mod);
                }

                // Each gear
                for (int g = 0; g < map[c].Count; g++)
                {
                    // Get gear mods
                    List<Ability> gearAbilities = GetAbilities_Gear(c, g);
                    List<Ability_Modifier> gearMods = new List<Ability_Modifier>();

                    for (int i = 0; i < gearAbilities.Count; i++)
                    {
                        Ability_Modifier mod = gearAbilities[i] as Ability_Modifier;
                        if (mod != null && mod.extent == ModExtent.Gear)
                            gearMods.Add(mod);
                    }

                    // Get, modify, and add to returnVal the activated abilities
                    // Uses the various Mods lists to know what can be applied to it
                    for (int i = 0; i < gearAbilities.Count; i++)
                    {
                        Ability_Activated activated = gearAbilities[i] as Ability_Activated;
                        if (activated == null)
                            continue;

                        //TODO: Actually apply the modification
                        //TODO: And also add to returnVal
                    }
                }
            }
            
            return returnVal;
        }
		
	}
}