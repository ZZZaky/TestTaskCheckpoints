using BezierSolution;
using BezierSolution.Extras;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFactory : MonoBehaviour
{
    public BezierSpline spline;

    void Start()
    {
        Debug.Log(spline[0].position);
    }
}
