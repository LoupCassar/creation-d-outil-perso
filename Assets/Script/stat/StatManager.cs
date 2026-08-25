using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    Stat stat;
    StatsScriptableObject statsScriptableObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Dictionary<string, Stat> stats;

    public void Start()
    {

        stats = statsScriptableObject.statBase.ToDictionary(s => s.name, s => s);

    }



}