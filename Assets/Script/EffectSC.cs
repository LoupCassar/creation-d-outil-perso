using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectSC", menuName = "Scriptable Objects/EffectSC")]
public class EffectSC : ScriptableObject
{
    public List<EffectData> effects;
}