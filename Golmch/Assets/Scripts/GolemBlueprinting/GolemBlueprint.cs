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
        public MediumSettings medium;
        public FrameSettings frame;

        public int armorCount = 10;

        public List<CompartmentBlueprint> compartments;


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
                if (compartments == null)
                    return 0;

                float gearsWeight = 0;

                for (int i = 0; i < compartments.Count; i++)
                    gearsWeight += compartments[i].GearsWeight;
                
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