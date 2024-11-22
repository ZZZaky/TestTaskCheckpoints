using BezierSolution;
using BezierSolution.Extras;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

/// <summary>
/// Creator of all Bezier curves
/// </summary>
public class BezierFactory : MonoBehaviour
{
    public BezierSpline spline;
    private int pointsCount;
    private List<Vector3> pointsContainer;

    void Awake()
    {
        pointsCount = 0;
        pointsContainer = new List<Vector3>();
    }

    public void CreatePoints(List<Vector3> points)
    {
        pointsCount = points.Count;
        if (!IsPossibleToConstruct())
        {
            pointsContainer = new List<Vector3>(points);
            return;
        }

        spline.Initialize(points.Count);
        for (int i = 0; i < points.Count; i++)
        {
            spline[i].position = points[i];
        }
        UpdateBezierSplines();
    }

    public void UpdatePoint(int index, Vector3 point)
    {
        if (!IsPossibleToConstruct())
        {
            pointsContainer[index] = point; 
            return;
        }

        spline[index].position = point;
        UpdateBezierSplines();
    }

    public void InsertPointAt(int index, Vector3 point)
    {
        pointsCount++;
        if (!IsPossibleToConstruct())
        {
            pointsContainer.Add(point);
            return;
        }
        
        if(pointsCount == 2)
        {
            pointsContainer.Insert(index, point);

            spline.Initialize(pointsCount);
            spline[0].position = pointsContainer[0];
            spline[1].position = pointsContainer[1];
        }
        else
        {
            spline.InsertNewPointAt(index);
            spline[index].position = point;
        }
        UpdateBezierSplines();
    }

    public void DeletePointAt(int index)
    {
        pointsCount--;
        if (!IsPossibleToConstruct())
        {
            pointsContainer.RemoveAt(index);
            return;
        }

        spline.RemovePointAt(index);
        UpdateBezierSplines();
    }

    public void ChangeRingRoad(bool state)
    {
        spline.loop = state;
        UpdateBezierSplines();
    }

    private void UpdateBezierSplines()
    {
        if (IsPossibleToConstruct()) { spline.AutoConstructSpline(); }
    }

    private bool IsPossibleToConstruct()
    {
        bool isPossible = pointsCount < 2 ? false : true;
        
        if (!isPossible && spline.enabled) 
        {
            pointsContainer = new List<Vector3>();
            pointsContainer.Add(spline[0].position);
            pointsContainer.Add(spline[1].position);
            spline.enabled = false;
        }
        else if (isPossible && !spline.enabled) 
        {
            spline.enabled = true;
        }

        return isPossible;
    }
}
