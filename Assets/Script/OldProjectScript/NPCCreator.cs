using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
public class Npc
{

}
public class LieuDeTravail
{

}
public class LieuDeRepos
{

}
public class LieuDeNonTravail
{

}
public class LieuDEtat
{

}

public class EditorWindowNpcCreator : EditorWindow
{
    bool aDesFaction;
    bool aFactionExperimental;
    bool aDesRoutineDeVie;
    bool aDesLieuDeTravail;
    bool aDesLieuDeRepos;
    bool aDesLieuDeNonTravail;
    bool aDesLieuDEtat;
    List<Npc> npcsPrefab = new List<Npc>();
    List<GameObject> lieuDeTravailPrefab = new List<GameObject>();
    List<GameObject> lieuDeReposPrefab = new List<GameObject>();
    List<GameObject> lieuDeNonTravailPrefab = new List<GameObject>();
    List<GameObject> LieuDEtatPrefab = new List<GameObject>();
    List<Npc> npcsGO = new List<Npc>();
    List<GameObject> lieuDeTravailGO = new List<GameObject>();
    List<GameObject> lieuDeReposPreGO = new List<GameObject>();
    List<GameObject> lieuDeNonTravailGO = new List<GameObject>();
    List<GameObject> LieuDEtatGO = new List<GameObject>();

    [MenuItem("Window/EditorWindowNpcCreator")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(EditorWindowNpcCreator));
    }
    private void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);

        aDesFaction = EditorGUILayout.BeginToggleGroup("On des faction Setting", aDesFaction);
        aFactionExperimental = EditorGUILayout.BeginToggleGroup("On des faction Setting", aFactionExperimental);

        EditorGUILayout.EndToggleGroup();
        EditorGUILayout.EndToggleGroup();
        aDesRoutineDeVie = EditorGUILayout.BeginToggleGroup("On des routine de vie Setting", aDesRoutineDeVie);
        EditorGUILayout.EndToggleGroup();
        aDesLieuDeTravail = EditorGUILayout.BeginToggleGroup("On des routine de vie Setting", aDesLieuDeTravail);
        EditorGUILayout.EndToggleGroup();
        aDesLieuDeRepos = EditorGUILayout.BeginToggleGroup("On des routine de vie Setting", aDesLieuDeRepos);
        EditorGUILayout.EndToggleGroup();
        aDesLieuDeNonTravail = EditorGUILayout.BeginToggleGroup("On des routine de vie Setting", aDesLieuDeNonTravail);
        EditorGUILayout.EndToggleGroup();
        aDesLieuDEtat = EditorGUILayout.BeginToggleGroup("On des routine de vie Setting", aDesLieuDEtat);
        EditorGUILayout.EndToggleGroup();
        EditorGUILayout.EndToggleGroup();
    }
}
public class NPCCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
