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

        public int armorCount = 10;

        public List<AddedGear> addedGears;
		

        public float TotalWeight
        {
            get
            {
                return FrameWeight + ArmorWeight + GearsWeight;
            }
        }

        public float FrameWeight
        {
            get
            {
                if (medium == null || frame == null)
                    return 0;
                return frame.volume * medium.density;
            }
        }

        public float ArmorWeight
        {
            get
            {
                if (medium == null || frame == null)
                    return 0;
                return (armorCount * frame.volumePerArmor) * medium.density;
            }
        }

        public float GearsWeight
        {
            get
            {
                float gearsWeight = 0;

                for (int i = 0; i < addedGears.Count; i++)
                    if (addedGears[i].gear != null)
                        gearsWeight += addedGears[i].gear.weight;

                return gearsWeight;
            }
        }


        public float ManaPerMove
        {
            get
            {
                if (frame == null)
                    return 0;
                return frame.manaPerMovePerWeight * TotalWeight;
            }
        }

	}
}