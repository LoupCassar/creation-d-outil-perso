using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SplineRoad))]
public class SplineRoadEditor : Editor
{

    public void OneRoad(Transform roadStart, Transform roadEnd)
    {

        RaycastHit hit;
        float distanceToObstacle = 0;

        if (Physics.CapsuleCast(roadStart.position, roadEnd.position, 10, roadStart.forward, out hit, 10))
            distanceToObstacle = hit.distance;
    }
    public void OnSceneGUI()
    {
        var t = target as SplineRoad;
        foreach (var roadSegment in t.splineRoads)
        {
            Handles.color = Color.green;
            Handles.SphereHandleCap(0, roadSegment.startPoint.pointTransform.position, Quaternion.identity, roadSegment.startPoint.pointWidth, EventType.Repaint);
            Handles.SphereHandleCap(0, roadSegment.endPoint.pointTransform.position, Quaternion.identity, roadSegment.endPoint.pointWidth, EventType.Repaint);
            Handles.color = Color.red;
            Handles.DrawLine(roadSegment.startPoint.pointTransform.position, roadSegment.endPoint.pointTransform.position);
            Handles.Label(roadSegment.startPoint.pointTransform.position, "Wealth: " + roadSegment.startPoint.pointWealth);
            Handles.Label(roadSegment.endPoint.pointTransform.position, "Wealth: " + roadSegment.endPoint.pointWealth);
            Handles.Label(roadSegment.startPoint.pointTransform.position + (roadSegment.endPoint.pointTransform.position / 2), roadSegment.segmentName);
            OneRoad(roadSegment.startPoint.pointTransform, roadSegment.endPoint.pointTransform);
        }

    }
}
[CustomEditor(typeof(Immeuble))]
public class Immeubleditor : Editor
{

    public void OnSceneGUI()
    {
        var t = target as Immeuble;
        foreach (var zip in t.zoneImmeublesPoint)
        {
            Handles.color = Color.green;
            Handles.SphereHandleCap(0, zip.position, Quaternion.identity, 1, EventType.Repaint);
        }

    }
}
