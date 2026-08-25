using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Objects/StatsScriptableObject")]
public class StatsScriptableObject : ScriptableObject
{
    public bool enumStatBase = false;

    public List<Stat> statBase = new List<Stat>();
    public Dictionary<string, Stat> stats;

}
public class Stat
{
    public string name;
    public float value;
    public float tempValue;
    public float maxValue;
    public float decreaseValue;
    public Stat(string name, float value, float maxValue, float decreaseValue)
    {
        this.name = name;
        this.value = value;
        this.tempValue = value;
        this.maxValue = maxValue;
        this.decreaseValue = decreaseValue;
    }
}