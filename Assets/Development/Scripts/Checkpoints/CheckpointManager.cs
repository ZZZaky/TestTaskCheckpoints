using BezierSolution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checkpoint Manager
//
public class CheckpointManager : MonoBehaviour
{
    public List<Checkpoint> allCheckpoints;
    public BezierFactory bezierFactory;

    void Start()
    {
        if (allCheckpoints == null || allCheckpoints.Count == 0)
        {
            allCheckpoints = new List<Checkpoint>();
        }
        else
        {
            Debug.Log(allCheckpoints.Count);
            List<Vector3> points = new List<Vector3>();
            foreach (var checkpoint in allCheckpoints) 
            { 
                Debug.Log(checkpoint.transform.position);
                points.Add(checkpoint.transform.position);
            }
            bezierFactory.CreatePoints(points);
        }
    }

    public void OnEnterCheckpoint(int checkpoint)
    {
        if (checkpoint == 0 || allCheckpoints[checkpoint - 1].checkpointPassed) 
        {
            DoneCheckpoint(checkpoint);
            if (checkpoint == allCheckpoints.Count - 1)
            {
                Finish();
            }
        }
    }

    public void DoneCheckpoint(int checkpoint)
    {
        allCheckpoints[checkpoint].CheckpointPassed();
    }

    public void AddCheckpoint(Checkpoint checkpoint)
    {
        allCheckpoints.Add(checkpoint);
    }

    public void DeleteCheckpoint(int checkpoint)
    {
        allCheckpoints.RemoveAt(checkpoint);
    }

    public void ResetCheckpoints()
    {
        foreach (var checkpoint in allCheckpoints)
        {
            checkpoint.Delete();
        }
        allCheckpoints = new List<Checkpoint>();
    }

    private void Finish()
    {
        // TODO
    }
}
