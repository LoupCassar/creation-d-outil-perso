using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectData
{
    public string objectName;
    public Sprite objectSprite;
    public GameObject effectPrefab;
    public int objectID;
    public float size;
    public int height;
    public int width;
    public List<EffectData> effect;
}
