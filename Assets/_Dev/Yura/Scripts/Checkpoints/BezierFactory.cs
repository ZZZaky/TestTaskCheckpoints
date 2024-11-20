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

    public void UpdateSpline()
    {
        UpdateBezierSplines();
    }

    public void InsertPointAt(Vector3 point, int index)
    {
        spline.InsertNewPointAt(index);
        spline[index].position = point;
        UpdateBezierSplines();
    }

    public void ChangeRingRoad(bool state)
    {
        spline.loop = state;
        UpdateBezierSplines();
    }

    public void DeletePointAt(int index)
    {
        spline.RemovePointAt(index);
        UpdateBezierSplines();
    }

    private void UpdateBezierSplines()
    {
        spline.AutoConstructSpline();
    }

}
