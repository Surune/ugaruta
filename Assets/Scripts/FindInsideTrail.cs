using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindInsideTrail : MonoBehaviour {
    public static TrailRendererWith2DCollider trailRenderer;
    public float radius = 1f;
    
    //private static List<Vector3> trailPoints = new List<Vector3>();
    private static List<Vector3> trailPoints;

    void Start()
    {
        // Get all the points along the trail
        //if(trailRenderer == null) trailRenderer = GameObject.Find("Player").GetComponent<TrailRendererWith2DCollider>();
        /*
        int pointCount = trailRenderer.positionCount;
        for (int i = 0; i < pointCount; i++)
        {
            Vector3 point = trailRenderer.GetPosition(i);
            trailPoints.Add(point);
        }
        */
    }
    /*
    void Update()
    {
        // Check if an object is inside the trail area
        trailPoints = trailRenderer.centerPositions;
        if (IsObjectInsideTrailArea(transform.position))
        {
            Debug.Log("Object is inside the trail area!");
        }
    }

    bool IsObjectInsideTrailArea(Vector3 objectPosition)
    {
        // Use the PointInPolygon algorithm to check if the object is inside the trail area
        bool isInside = false;
        int j = trailPoints.Count - 1;
        for (int i = 0; i < trailPoints.Count; i++)
        {
            if ((trailPoints[i].z < objectPosition.z && trailPoints[j].z >= objectPosition.z
                || trailPoints[j].z < objectPosition.z && trailPoints[i].z >= objectPosition.z)
                && (trailPoints[i].x <= objectPosition.x || trailPoints[j].x <= objectPosition.x))
            {
                if (trailPoints[i].x + (objectPosition.z - trailPoints[i].z) / (trailPoints[j].z - trailPoints[i].z) * (trailPoints[j].x - trailPoints[i].x) < objectPosition.x)
                {
                    isInside = !isInside;
                }
            }
            j = i;
        }
        return isInside;
    }
    */
}