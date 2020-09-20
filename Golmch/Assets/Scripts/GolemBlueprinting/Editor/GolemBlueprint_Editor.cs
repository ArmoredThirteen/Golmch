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
        private static bool showCompartments = true;
        private static bool showReadout = true;


        public override void OnInspectorGUI()
        {
            targ = (GolemBlueprint)this.target;
            
            GUILayout.BeginVertical ("Medium", "window");
            OnDisplayMedium ();
            GUILayout.EndVertical ();
            EditorGUILayout.Space ();

            GUILayout.BeginVertical ("Frame", "window");
            OnDisplayFrame ();
            GUILayout.EndVertical ();
            EditorGUILayout.Space ();

            OnDisplayOrphanGears ();
            EditorGUILayout.Space ();

            GUILayout.BeginVertical ("Compartments", "window");
            OnDisplayCompartments ();
            GUILayout.EndVertical ();
            EditorGUILayout.Space ();

            GUILayout.BeginVertical ("Readout", "window");
            OnDisplayReadout ();
            GUILayout.EndVertical ();
        }


        private void OnDisplayMedium()
        {
            targ.medium = (MediumSettings)EditorGUILayout.ObjectField("Medium:", targ.medium, typeof(MediumSettings), false);

            showMediumValues = EditorGUILayout.Foldout (showMediumValues, "Show Medium");
            if (!showMediumValues)
                return;

            // Shows internal values in the chosen medium, not editable
            string[] splitStr = targ.medium.ToString ().Split ('\n');
            for (int i = 0; i < splitStr.Length; i++)
                EditorGUILayout.LabelField ("    " + splitStr[i]);
        }

        private void OnDisplayFrame()
        {
            targ.frame = (FrameSettings)EditorGUILayout.ObjectField("Frame:", targ.frame, typeof(FrameSettings), false);

            showFrameValues = EditorGUILayout.Foldout(showFrameValues, "Show Frame");
            if (!showFrameValues)
                return;

            // Shows internal values in the chosen frame, not editable
            string[] splitStr = targ.frame.ToString ().Split ('\n');
            for (int i = 0; i < splitStr.Length; i++)
                EditorGUILayout.LabelField ("    " + splitStr[i]);
        }


        private void OnDisplayOrphanGears()
        {
            // Gather any orphans
            int compCount = targ.frame.compartments.Length;
            List<GolemBlueprint.AddedGear> orphans = targ.addedGears.FindAll (gear => gear.compartmentIndex >= compCount);
            if (orphans.Count <= 0)
                return;

            EditorGUILayout.HelpBox ("Gear(s) with broken compartment indexes!", MessageType.Error);
            GUILayout.BeginVertical ("window");

            // Remove all orphans
            if (GUILayout.Button ("Remove all"))
            {
                targ.addedGears.RemoveAll (gear => gear.compartmentIndex >= compCount);
                EditorUtility.SetDirty (targ);
                return;
            }

            EditorGUILayout.Space ();

            // Display and remove each orphan
            for (int i = 0; i < targ.addedGears.Count; i++)
            {
                if (targ.addedGears[i].compartmentIndex < compCount)
                    continue;
                if (DisplayGear (i))
                    return;
            }

            GUILayout.EndVertical ();
        }


        private void OnDisplayCompartments()
        {
            showCompartments = EditorGUILayout.Foldout (showCompartments, "Show Compartments and Gear");
            if (!showCompartments)
                return;

            //TODO: Double for loop, find better solution
            //      Currently required due to addedGears index needing to be known for removal operation
            for (int i = 0; i < targ.frame.compartments.Length; i++)
            {
                GUILayout.BeginVertical ("Compartment " + i + ", " + targ.frame.compartments[i].displayName, "window");

                // Create new gear, display at top so it stays in place when pressing multiple times
                if (GUILayout.Button ("Add New Gear"))
                {
                    targ.addedGears.Add (new GolemBlueprint.AddedGear (i));
                    EditorUtility.SetDirty (targ);
                    return;
                }

                EditorGUILayout.Space ();

                // Each gear belonging to this compartment
                for (int k = 0; k < targ.addedGears.Count; k++)
                {
                    if (targ.addedGears[k].compartmentIndex != i)
                        continue;

                    if (DisplayGear (k))
                        return;
                }

                GUILayout.EndVertical ();
                EditorGUILayout.Space ();
                EditorGUILayout.Space ();
            }
        }

        /*
         * Shows gear at given index within addedGears.
         * If remove button was clicked, deletes the gear and returns true.
         */
        private bool DisplayGear(int addedIndex)
        {
            GolemBlueprint.AddedGear gear = targ.addedGears[addedIndex];
            bool removePressed = false;

            string windowName = "Gear" + (gear.gear == null ? "" : ": " + gear.gear.displayName);
            GUILayout.BeginVertical (windowName, "window");

            // Get the serialized addedGear
            SerializedProperty serializedList = serializedObject.FindProperty("addedGears");
            SerializedProperty serialized = serializedList.GetArrayElementAtIndex (addedIndex);

            // Get the serialized properties within addedGear
            SerializedProperty compartmentIndex = serialized.FindPropertyRelative ("compartmentIndex");
            SerializedProperty gearSettings = serialized.FindPropertyRelative ("gear");

            // Make the fields for the properties
            EditorGUILayout.PropertyField (compartmentIndex, new GUIContent ("Compartment Index"), true);
            EditorGUILayout.PropertyField (gearSettings, new GUIContent ("Gear Settings"), true);

            // Ensure serialization happens
            serializedObject.ApplyModifiedProperties ();
            
            if (GUILayout.Button ("Remove"))
            {
                targ.addedGears.RemoveAt (addedIndex);
                EditorUtility.SetDirty (targ);
                removePressed = true;
            }

            GUILayout.EndVertical ();
            EditorGUILayout.Space ();
            return removePressed;
        }


        private void OnDisplayReadout()
        {
            showReadout = EditorGUILayout.Foldout (showReadout, "Show Readout");
            if (!showReadout)
                return;

            EditorGUILayout.LabelField ("Frame Weight: " + targ.FrameWeight);
            EditorGUILayout.LabelField ("Total Weight: " + targ.TotalWeight);
        }
		
	}
}