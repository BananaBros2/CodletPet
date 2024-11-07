using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{

    public GameObject[] linePoints = new GameObject[0];
    private Vector3[] linePositions = new Vector3[0];
    private LineRenderer lineRenderer = null;

    int index = 0;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = linePoints.Length;
    }

    private void LateUpdate()
    {

        index = -1;
        foreach (GameObject point in linePoints)
        {
            index++;
            lineRenderer.SetPosition(index, point.transform.position);
        }


        //lineRenderer.SetPositions(linePositions);
    }

}

