using BezierSolution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Manager for all checkpoints present
/// </summary>
public class CheckpointManager : MonoBehaviour
{
    public bool ringRoad = false;
    public List<Checkpoint> allCheckpoints;
    public GameObject checkpointPrefab;

    [Inject] private BezierFactory bezierFactory;
    [Inject] private DiContainer diContainer;
    [Inject] private SelectedObjectManager selectedObjectManager;

    void Start()
    {
        if (allCheckpoints == null || allCheckpoints.Count < 2)
        {
            allCheckpoints = new List<Checkpoint>();
        }
        else
        {
            List<Vector3> points = new List<Vector3>();
            foreach (var checkpoint in allCheckpoints) 
            {
                points.Add(checkpoint.transform.position);
            }
            bezierFactory.CreatePoints(points);
        }
        ChangeRingRoad(false);
    }

    public void OnEnterCheckpoint(int checkpoint)
    {
        if (checkpoint == 0 || allCheckpoints[checkpoint - 1].isPassed) 
        {
            allCheckpoints[checkpoint].CheckpointPassed();
            if (checkpoint == allCheckpoints.Count - 1)
            {
                OnFinish();
            }
        }
    }

    public void CreateCheckpointAt(int index)
    {
        GameObject newCheckpoint = diContainer.InstantiatePrefab(checkpointPrefab, new Vector3(0, 0, 0), Quaternion.identity, null);

        // index = -1 зарезервирован для создания нового последнего чекпоинта в редакторе
        int newCheckpointIndex = index == -1 ? allCheckpoints.Count : index;
        bezierFactory.InsertPointAt(newCheckpointIndex, newCheckpoint.transform.position);
        InsertCheckpointAt(newCheckpoint.GetComponent<Checkpoint>(), newCheckpointIndex);
        for (int i = newCheckpointIndex + 1; i < allCheckpoints.Count; i++)
        {
            allCheckpoints[i].checkpointNumber++;
        }
    }

    public void DeleteCheckpointAt(int index)
    {
        selectedObjectManager.DeselectObject();
        allCheckpoints[index].Delete();
        for (int i = index + 1; i < allCheckpoints.Count; i++ )
        {
            allCheckpoints[i].checkpointNumber--;
        }
        bezierFactory.DeletePointAt(index);
        allCheckpoints.RemoveAt(index);
    }

    public void ResetCheckpoints()
    {
        foreach (var checkpoint in allCheckpoints)
        {
            checkpoint.Delete();
        }
        allCheckpoints = new List<Checkpoint>();
    }

    public void ChangeRingRoad(bool state)
    {
        ringRoad = state;
        bezierFactory.ChangeRingRoad(ringRoad);
    }

    private void InsertCheckpointAt(Checkpoint checkpoint, int index)
    {
        checkpoint.checkpointNumber = index;
        allCheckpoints.Insert(index, checkpoint);
    }

    private void OnFinish()
    {
        // TODO
    }
}
