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
        UpdateBezierSplines();
    }

    public void UpdatePoint(int index, Vector3 point)
    {
        spline[index].position = point;
        UpdateBezierSplines();
    }

    public void AddPoint(Vector3 point)
    {
        Debug.Log($"Checkpoints: {spline.Count}");
        spline.InsertNewPointAt(spline.Count);
        spline[spline.Count - 1].position = point;
        Debug.Log($"Checkpoints: {spline.Count}");
    }

    public void UpdateBezierSplines()
    {
        spline.AutoConstructSpline();
    }
}
