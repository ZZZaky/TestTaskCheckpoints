using BezierSolution;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

/// <summary>
/// Manager for all checkpoints present
/// </summary>
public class CheckpointManager : MonoBehaviour
{
    public bool ringRoad = false;
    public List<Checkpoint> allCheckpoints;
    public GameObject checkpointPrefab;

    public Toggle ringRoadToggle; // temporary solution

    [Inject] private BezierFactory bezierFactory;
    [Inject] private DiContainer diContainer;
    [Inject] private SelectedObjectManager selectedObjectManager;
    [Inject] private PlayerManager playerManager;

    public void InitializeCheckpoints()
    {
        List<Vector3> points = new List<Vector3>();
        foreach (Checkpoint checkpoint in allCheckpoints)
        {
            points.Add(checkpoint.transform.position);
        }
        bezierFactory.CreatePoints(points);
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

        selectedObjectManager.DeselectObject();
    }

    public void CreateCheckpointFromMap(CheckpointData checkpoint)
    {
        GameObject newCheckpoint = diContainer.InstantiatePrefab(checkpointPrefab, 
            new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y, checkpoint.transform.position.z),
            new Quaternion(checkpoint.transform.rotation.x, checkpoint.transform.rotation.y, checkpoint.transform.rotation.z, checkpoint.transform.rotation.w), 
            null);

        int newCheckpointIndex = allCheckpoints.Count;
        bezierFactory.InsertPointAt(newCheckpointIndex, newCheckpoint.transform.position);
        InsertCheckpointAt(newCheckpoint.GetComponent<Checkpoint>(), newCheckpointIndex);
        selectedObjectManager.DeselectObject();
    }

    public void DeleteCheckpointAt(int index)
    {
        selectedObjectManager.DeselectObject();
        allCheckpoints[index].Delete();
        for (int i = index + 1; i < allCheckpoints.Count; i++ )
        {
            allCheckpoints[i].checkpointNumber--;
        }

        selectedObjectManager.DeselectObject();
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
        InitializeCheckpoints();

        selectedObjectManager.DeselectObject();
    }

    public void ChangeRingRoad(bool state)
    {
        ringRoad = state;
        bezierFactory.ChangeRingRoad(ringRoad);
        ringRoadToggle.isOn = ringRoad;
    }

    public void ResetPassedCheckpoints()
    {
        for (int i = 0; i < allCheckpoints.Count; i++)
        {
            allCheckpoints[i].isPassed = false;
        }
    }

    private void InsertCheckpointAt(Checkpoint checkpoint, int index)
    {
        checkpoint.checkpointNumber = index;
        allCheckpoints.Insert(index, checkpoint);
        selectedObjectManager.DeselectObject();
    }

    private void OnFinish()
    {
        playerManager.currentPlayer.GetComponent<PlayerWin>().Pause();
    }
}
