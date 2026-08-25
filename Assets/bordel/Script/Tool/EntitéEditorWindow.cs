using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EntitéEditorWindow : EditorWindow
{
    public class EntitéWindow : EditorWindow
    {
        //EntiteComposistionV2 entiteComposistion;

        [MenuItem("Tools/Entité/EntitéGestion")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(EntitéWindow));
        }
        void OnGUI()
        {
            /*
            if (entiteComposistion == null)
            {
                entiteComposistion = new EntiteComposistionV2();
            }
            else
            
            GUILayout.BeginVertical();
            foreach (Entite entite in entiteComposistion.entiteList)
            {
                GUILayout.BeginHorizontal();
                if (entite.entiteGO == null)
                    EditorGUILayout.LabelField("ya r frere");
                else
                {
                    EditorGUILayout.LabelField(entite.entiteGO.name);
                    GUILayout.BeginVertical();
                    foreach (var stat in entite.entiteStats)
                    {
                        GUILayout.BeginHorizontal();
                        EditorGUILayout.LabelField(stat.Key.ToString());
                        EditorGUILayout.LabelField("StatLevel");
                        EditorGUILayout.FloatField(stat.Value.StatLevel);
                        EditorGUILayout.LabelField("StatLevelTemporere");
                        EditorGUILayout.FloatField(stat.Value.StatLevelTemporere);
                        EditorGUILayout.LabelField("MinDeLaStat");
                        EditorGUILayout.FloatField(stat.Value.MinDeLaStat);
                        EditorGUILayout.LabelField("DiminutionDeLaStat");
                        EditorGUILayout.FloatField(stat.Value.DiminutionDeLaStat);
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.EndHorizontal();
                    if (GUILayout.Button("Select"))
                    {
                        Selection.activeGameObject = entite.entiteGO;
                    }
                }
                GUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
            */
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
