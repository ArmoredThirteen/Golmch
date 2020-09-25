using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private static bool confirmReloadCompartments = false;


        public override void OnInspectorGUI()
        {
            targ = (GolemBlueprint)target;

            GUILayout.BeginVertical ("Medium", "window");
            OnDisplayMedium ();
            GUILayout.EndVertical ();
            EditorGUILayout.Space ();

            GUILayout.BeginVertical ("Frame", "window");
            OnDisplayFrame ();
            GUILayout.EndVertical ();
            EditorGUILayout.Space ();

            GUILayout.BeginVertical ("Compartments", "window");
            OnDisplayCompartments ();
            GUILayout.EndVertical ();
            EditorGUILayout.Space ();

            GUILayout.BeginVertical ("Readout", "window");
            OnDisplayReadout ();
            GUILayout.EndVertical ();

            if (GUI.changed)
                EditorUtility.SetDirty (targ);
        }


        private void OnDisplayMedium()
        {
            targ.medium = (MediumSettings)EditorGUILayout.ObjectField("Medium", targ.medium, typeof(MediumSettings), false);

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
            targ.frame = (FrameSettings)EditorGUILayout.ObjectField("Frame", targ.frame, typeof(FrameSettings), false);
            targ.armorCount = EditorGUILayout.IntField ("Armor Count", targ.armorCount);

            if (!confirmReloadCompartments)
            {
                if (GUILayout.Button ("Reload Compartments"))
                    confirmReloadCompartments = true;
            }
            else
            {
                if (GUILayout.Button ("Definitely Reload?"))
                {
                    ReloadCompartments ();
                    confirmReloadCompartments = false;
                }
                EditorGUILayout.HelpBox ("Reload will wipe all compartment and gear settings!", MessageType.Warning);
            }

            showFrameValues = EditorGUILayout.Foldout(showFrameValues, "Show Frame");
            if (!showFrameValues)
                return;

            // Shows internal values in the chosen frame, not editable
            string[] splitStr = targ.frame.ToString ().Split ('\n');
            for (int i = 0; i < splitStr.Length; i++)
                EditorGUILayout.LabelField ("    " + splitStr[i]);
        }

        private void ReloadCompartments()
        {
            targ.compartments.Clear ();

            for (int i = 0; i < targ.frame.compartments.Length; i++)
            {
                CompartmentBlueprint newPrint = new CompartmentBlueprint (targ.frame.compartments[i]);
                targ.compartments.Add (newPrint);
            }
        }


        private void OnDisplayCompartments()
        {
            showCompartments = EditorGUILayout.Foldout (showCompartments, "Show Compartments and Gear");
            if (!showCompartments)
                return;

            if (targ.compartments == null)
                return;

            for (int compInd = 0; compInd < targ.compartments.Count; compInd++)
            {
                CompartmentBlueprint currComp = targ.compartments[compInd];
                GUILayout.BeginVertical ("Compartment " + compInd + ", " + currComp.settings.displayName, "window");

                int totalSlots = currComp.TotalSlots;
                int usedSlots = currComp.UsedSlots;

                // Turn text red if using too many slots
                GUIStyle slotsLabelStyle = new GUIStyle(EditorStyles.label);
                if (usedSlots > totalSlots)
                    slotsLabelStyle.normal.textColor = Color.red;
                
                EditorGUILayout.LabelField ("Slots, used/total:  " + usedSlots + " / " + totalSlots, slotsLabelStyle);
                EditorGUILayout.Space ();

                if (GUILayout.Button ("Add Gear"))
                    currComp.gears.Add (null);

                EditorGUILayout.Space ();

                for (int gearInd = 0; gearInd < currComp.gears.Count; gearInd++)
                    DisplayGear (currComp.gears, gearInd);

                GUILayout.EndVertical ();
                EditorGUILayout.Space ();
                EditorGUILayout.Space ();
            }
        }

        private void DisplayGear(List<GearSettings> gears, int index)
        {
            string windowName = "Gear" + (gears[index] == null ? "" : ": " + gears[index].displayName);
            GUILayout.BeginVertical (windowName, "window");

            gears[index] = (GearSettings)EditorGUILayout.ObjectField("Gear Settings", gears[index], typeof(GearSettings), false);

            if (GUILayout.Button ("Remove"))
                gears.RemoveAt (index);

            GUILayout.EndVertical ();
            EditorGUILayout.Space ();
        }


        private void OnDisplayReadout()
        {
            showReadout = EditorGUILayout.Foldout (showReadout, "Show Readout");
            if (!showReadout)
                return;
            
            GUILayout.BeginVertical ("Total Weight: " + targ.TotalWeight, "window");
            EditorGUILayout.LabelField ("Frame: " + targ.FrameWeight);
            EditorGUILayout.LabelField ("Armor: " + targ.ArmorWeight);
            EditorGUILayout.LabelField ("Gears: " + targ.GearsWeight);
            GUILayout.EndVertical ();

            EditorGUILayout.LabelField ("Mana per Move: " + targ.ManaPerMove);
        }
		
	}
}