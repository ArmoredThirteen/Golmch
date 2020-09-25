using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    [System.Serializable]
	public class CompartmentBlueprint
	{
        public CompartmentSettings settings;
        public List<GearSettings> gears;


        public CompartmentBlueprint(CompartmentSettings theSettings)
        {
            settings = theSettings;
            this.gears = new List<GearSettings> ();
        }


        public int TotalSlots
        {
            get
            {
                if (settings == null)
                    return 0;
                return settings.slots;
            }
        }

        public int UsedSlots
        {
            get
            {
                int usedSlots = 0;

                for (int i = 0; i < gears.Count; i++)
                    if (gears[i] != null)
                        usedSlots += gears[i].slots;

                return usedSlots;
            }
        }


        public float GearsWeight
        {
            get
            {
                float gearsWeight = 0;

                for (int i = 0; i < gears.Count; i++)
                    if (gears[i] != null)
                        gearsWeight += gears[i].weight;

                return gearsWeight;
            }
        }
		
	}
}