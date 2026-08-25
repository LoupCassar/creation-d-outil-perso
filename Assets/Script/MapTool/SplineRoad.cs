using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class SplineRoad : MonoBehaviour
{

    [SerializeField] public List<SpLineRoadSegment> splineRoads = new List<SpLineRoadSegment>();

}
[System.Serializable]
public class SpLineRoadPoint 
{
    public Transform pointTransform;
    public float pointWidth;
    public int pointWealth;
    public SpLineRoadPoint(Transform transform,float width,int wealth)
    {
        pointTransform = transform;
        pointWidth = width;
        pointWealth = wealth;
    }
}
[System.Serializable]
public class SpLineRoadSegment
{
    public SpLineRoadPoint startPoint;
    public SpLineRoadPoint endPoint;
    public string segmentName;
    public SpLineRoadSegment(SpLineRoadPoint start, SpLineRoadPoint end)
    {
        startPoint = start;
        endPoint = end;
    }
}