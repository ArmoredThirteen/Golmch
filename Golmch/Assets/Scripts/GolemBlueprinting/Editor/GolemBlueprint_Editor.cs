using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ATE
{
    [CustomEditor(typeof(GolemBlueprint))]
	public class GolemBlueprint_Editor : Editor
	{
        private GolemBlueprint targ;

        private static bool showFrameValues = false;
        private static bool showMediumValues = false;


        public override void OnInspectorGUI()
        {
            targ = (GolemBlueprint)this.target;
            
            OnDisplayMedium ();
            OnDisplayFrame ();
            EditorGUILayout.Space ();

            OnDisplayAddedGears ();
            EditorGUILayout.Space ();

            EditorGUILayout.LabelField ("Weight: " + targ.Weight);
        }

        private void OnDisplayMedium()
        {
            targ.medium = (MediumSettings)EditorGUILayout.ObjectField("Medium:", targ.medium, typeof(MediumSettings), false);

            showMediumValues = EditorGUILayout.Foldout (showMediumValues, "Show Medium Values");
            if (showMediumValues)
            {
                string[] splitStr = targ.medium.ToString ().Split ('\n');
                for (int i = 0; i < splitStr.Length; i++)
                    EditorGUILayout.LabelField ("    " + splitStr[i]);
                EditorGUILayout.Space ();
            }
        }

        private void OnDisplayFrame()
        {
            targ.frame = (FrameSettings)EditorGUILayout.ObjectField("Frame:", targ.frame, typeof(FrameSettings), false);

            showFrameValues = EditorGUILayout.Foldout(showFrameValues, "Show Frame Values");
            if (showFrameValues)
            {
                string[] splitStr = targ.frame.ToString ().Split ('\n');
                for (int i = 0; i < splitStr.Length; i++)
                    EditorGUILayout.LabelField ("    " + splitStr[i]);
            }
        }

        private void OnDisplayAddedGears()
        {
            // Find all the orphans
            List<GolemBlueprint.AddedGear> orphans = targ.addedGears.FindAll
                (gear => gear.compartmentIndex >= targ.frame.compartments.Length);

            if (orphans.Count > 0)
            {
                EditorGUILayout.HelpBox ("Gear(s) with broken compartment indexes!", MessageType.Error);
                if (GUILayout.Button ("Remove all"))
                {
                    targ.addedGears.RemoveAll
                        (gear => gear.compartmentIndex >= targ.frame.compartments.Length);
                }
                /*else
                {
                    for (int i = 0; i < orphans.Count; i++)
                        DisplayAddedGear (i);
                }*/
            }

            for (int i = 0; i < targ.frame.compartments.Length; i++)
            {
                List<GolemBlueprint.AddedGear> gears = targ.addedGears.FindAll
                    (gear => gear.compartmentIndex == i);

                EditorGUILayout.LabelField ("Compartment " + i + ": " + targ.frame.compartments[i].displayName);
                EditorGUI.indentLevel++;

                if (GUILayout.Button ("Add New"))
                {
                    targ.addedGears.Add (new GolemBlueprint.AddedGear (i));
                    EditorUtility.SetDirty (targ);
                    return;
                }

                DisplayCompartmentGear (i);
                EditorGUILayout.Space ();
                EditorGUI.indentLevel--;
            }
        }

        private void DisplayCompartmentGear(int compartmentIndex)
        {
            SerializedProperty serializedList = serializedObject.FindProperty("addedGears");
            int labelIndex = 0;

            for (int i = 0; i < targ.addedGears.Count; i++)
            {
                if (targ.addedGears[i].compartmentIndex != compartmentIndex)
                    continue;

                SerializedProperty serialized = serializedList.GetArrayElementAtIndex (i);
                EditorGUILayout.PropertyField (serialized, new GUIContent ("Gear " + labelIndex), true);
                serializedObject.ApplyModifiedProperties ();

                if (GUILayout.Button ("Remove"))
                {
                    targ.addedGears.RemoveAt (i);
                    EditorUtility.SetDirty (targ);
                    return;
                }

                EditorGUILayout.Space ();
                labelIndex++;
            }
        }
		
	}
}