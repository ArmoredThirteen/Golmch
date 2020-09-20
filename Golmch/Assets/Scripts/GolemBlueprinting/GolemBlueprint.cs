using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    /*
     * Storing, modifying, and validating settings for a specific golem.
     * Not the in-game object, but is used to build an in-game object.
     */
	public class GolemBlueprint : MonoBehaviour
	{
        [System.Serializable]
        public class AddedGear
        {
            public int compartmentIndex;
            public GearSettings gear;

            public AddedGear(int theCompIndex)
            {
                compartmentIndex = theCompIndex;
            }
        }

        
        public MediumSettings medium;
        public FrameSettings frame;

        public List<AddedGear> addedGears;
		
        public float FrameWeight
        {
            get
            {
                if (medium == null || frame == null)
                    return 0;
                return medium.density * frame.volume;
            }
        }

        public float TotalWeight
        {
            get
            {
                float totalWeight = FrameWeight;
                for (int i = 0; i < addedGears.Count; i++)
                    if (addedGears[i].gear != null)
                        totalWeight += addedGears[i].gear.weight;
                return totalWeight;
            }
        }

	}
}