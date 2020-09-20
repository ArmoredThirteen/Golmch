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
            SerializedProperty property = serializedObject.FindProperty("addedGears");
            EditorGUILayout.PropertyField(property, new GUIContent("Added Gears"), true);
            serializedObject.ApplyModifiedProperties();
        }
		
	}
}