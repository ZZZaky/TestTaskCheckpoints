using BezierSolution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checkpoint Manager
//
public class CheckpointManager : MonoBehaviour
{
    public List<Checkpoint> allCheckpoints;

    void Start()
    {
        if (allCheckpoints == null || allCheckpoints.Count == 0)
        {
            allCheckpoints = new List<Checkpoint>();
        }




        // TEST //

        // y = k*x + b
        // k - угловой коэффициент (тангенс угла, образованного данной прямой и положительным направлением оси 0Y (0Z))
        // b - свободный коэффициент (пересечение с осью 0X)
        // 

        double global_x1 = -20, global_y1 = -20, angle1 = -45;
        double global_x2 = 0, global_y2 = -30, angle2 = -120;


        double x1 = global_x1 - global_x2;
        double x2 = 0;

        double y1 = 0;
        double y2 = global_y2 - global_y1;

        double b1 = 0;
        double b2 = y2;

        double k1 = System.Math.Round(System.Math.Tan(angle1), 1);
        double k2 = System.Math.Round(System.Math.Tan(angle2), 1);

        double x = -(b1 - b2) * (k1 - k2);
        double y = k1 * x + b1;

        //Debug.Log($"{y1} = {k1}*{x1} + {b1}");
        //Debug.Log($"{y2} = {k2}*{x2} + {b2}");
        //Debug.Log($"x: {x}, z: {y}");

        // TEST //
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
