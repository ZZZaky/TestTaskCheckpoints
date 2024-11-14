using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� ����������
//
public class CheckpointManager : MonoBehaviour
{
    public List<Checkpoint> allCheckpoints;

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
        allCheckpoints[checkpoint].checkpointPassed = true;
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
