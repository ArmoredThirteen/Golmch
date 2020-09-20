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

        public AddedGear[] addedGears;
		
        public float Weight
        {
            get
            {
                return medium.density * frame.volume;
            }
        }

	}
}