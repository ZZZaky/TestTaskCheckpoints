using BezierSolution;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creator of all Bezier splines
/// </summary>
public class BezierFactory : MonoBehaviour
{
    public BezierSpline spline;
    private int pointsCount;
    // for when we don't have enough points (<2) to construct spline
    private List<Vector3> pointsContainer;

    /// <summary>
    /// Create bezier curves from the list of points
    /// </summary>
    /// <param name="points">List of points</param>
    public void CreatePoints(List<Vector3> points)
    {
        pointsCount = points.Count;
        if (!IsPossibleToConstruct())
        {
            // If we can't construct Bezier spline, we save the point in our container for futuer construction
            pointsContainer = new List<Vector3>(points);
            return;
        }

        spline.Initialize(points.Count);
        // Setting all points' positions
        for (int i = 0; i < points.Count; i++)
        {
            spline[i].position = points[i];
        }
        UpdateBezierSplines();
    }

    /// <summary>
    /// Update existing point's location for bezier splines
    /// </summary>
    /// <param name="index">Index of the point</param>
    /// <param name="point">New point's location</param>
    public void UpdatePoint(int index, Vector3 point)
    {
        if (!IsPossibleToConstruct())
        {
            // If we can't construct Bezier spline, we save the point in our container for futuer construction
            pointsContainer[index] = point; 
            return;
        }

        spline[index].position = point;
        UpdateBezierSplines();
    }

    /// <summary>
    /// Create new point for bezier splines in the specific index
    /// </summary>
    /// <param name="index">Index of the new point</param>
    /// <param name="point">New point's location</param>
    public void InsertPointAt(int index, Vector3 point)
    {
        pointsCount++;
        if (!IsPossibleToConstruct())
        {
            // If we can't construct Bezier spline, we save the point in our container for futuer construction
            pointsContainer.Add(point);
            return;
        }
        
        if(pointsCount == 2)
        {
            // == 2 -> means we couldn't construct Bezier spline before, but now we can
            // we should use the point from container to construct
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

    /// <summary>
    /// Delete specific point in bezier spline
    /// </summary>
    /// <param name="index">Index of the to be deleted point</param>
    public void DeletePointAt(int index)
    {
        pointsCount--;
        if (!IsPossibleToConstruct())
        {
            // If we can't construct Bezier spline, we change the point in our container for futuer construction
            pointsContainer.RemoveAt(index);
            return;
        }

        spline.RemovePointAt(index);
        UpdateBezierSplines();
    }

    /// <summary>
    /// Change the ring road parameter
    /// </summary>
    /// <param name="state">New parameter for the ring road</param>
    public void ChangeRingRoad(bool state)
    {
        spline.loop = state;
        UpdateBezierSplines();
    }

    /// <summary>
    /// Update Bezier's curves
    /// </summary>
    private void UpdateBezierSplines()
    {
        if (IsPossibleToConstruct()) { spline.AutoConstructSpline(); }
    }

    /// <summary>
    /// Check if Bezier splines can be constructed
    /// </summary>
    /// <returns>The ability to build</returns>
    private bool IsPossibleToConstruct()
    {
        bool isPossible = pointsCount < 2 ? false : true;
        
        if (!isPossible && spline.enabled) 
        {
            // If we can't construct the Bezier spline but the spline is active in scene
            // we store the existing points in our container and turn off the spline in scene
            pointsContainer = new List<Vector3>();
            pointsContainer.Add(spline[0].position);
            pointsContainer.Add(spline[1].position);
            spline.enabled = false;
        }
        else if (isPossible && !spline.enabled) 
        {
            // If we can construct the Bezier spline but the spline isn't active in scene
            // we turn on the spline
            spline.enabled = true;
        }

        return isPossible;
    }
}
