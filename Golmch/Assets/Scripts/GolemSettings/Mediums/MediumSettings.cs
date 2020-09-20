using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    [CreateAssetMenu (fileName = "Medium_", menuName = "Golems/Medium", order = 150)]
    public class MediumSettings : ScriptableObject
    {
        public string displayName = "DEFAULT";
        public float density = 1;
    }
}
