using BezierSolution;
using BezierSolution.Extras;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creator of all Bezier curves
/// </summary>
public class BezierFactory : MonoBehaviour
{
    public BezierSpline spline;

    public void CreatePoints(List<Vector3> points)
    {
        spline.Initialize(points.Count);
        for (int i = 0; i < points.Count; i++)
        {
            spline[i].position = points[i];
        }
        spline.AutoConstructSpline();
    }

    public void AddPoint(Vector3 point)
    {
        spline.InsertNewPointAt(spline.Count);
        spline[spline.Count - 1].position = point;
    }
}
