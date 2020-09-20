using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ATE
{
    [CustomEditor(typeof(GolemBlueprint))]
	public class GolemBlueprint_Editor : Editor
	{
		public override void OnInspectorGUI()
        {
            GolemBlueprint targ = (GolemBlueprint)this.target;
            base.OnInspectorGUI ();

            EditorGUILayout.Space ();

            EditorGUILayout.LabelField ("Weight: " + targ.Weight);
        }
		
	}
}