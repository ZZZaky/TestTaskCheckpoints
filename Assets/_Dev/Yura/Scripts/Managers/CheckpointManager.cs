using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

/// <summary>
/// Manager for all checkpoints on scene
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

    /// <summary>
    /// Create Bezier spline from current checkpoints
    /// </summary>
    public void InitializeCheckpoints()
    {
        List<Vector3> points = new List<Vector3>();
        foreach (Checkpoint checkpoint in allCheckpoints)
        {
            points.Add(checkpoint.transform.position);
        }
        bezierFactory.CreatePoints(points);
    }

    /// <summary>
    /// The event when player enters checkpoint
    /// </summary>
    /// <param name="index"></param>
    public void OnEnterCheckpoint(int index)
    {
        // Check if player enters the first checkpoint or the previous checkpoint was entered
        if (index == 0 || allCheckpoints[index - 1].isPassed) 
        {
            allCheckpoints[index].CheckpointPassed();
            playerManager.currentPlayer.GetComponent<PlayerUI>().PassingCheckpoints();

            allCheckpoints[index].GetComponent<Outline>().enabled = false;
            if (index == allCheckpoints.Count - 1) { OnFinish(); }
            else { allCheckpoints[index + 1].GetComponent<Outline>().enabled = true; }
        }
    }

    /// <summary>
    /// Create new checkpoint at the specific index
    /// </summary>
    /// <param name="index">Index of the new checkpoint</param>
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

    /// <summary>
    /// Create new checkpoint at last index using info from <see cref="CheckpointData"/>
    /// </summary>
    /// <param name="checkpoint"></param>
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

    /// <summary>
    /// Delete checkpoint at the specific index
    /// </summary>
    /// <param name="index">Index of the deleting chechpoint</param>
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

    /// <summary>
    /// Reset (delete) all checkpoints in scene
    /// </summary>
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

    /// <summary>
    /// Change ring road's state to new state
    /// </summary>
    /// <param name="state">New state</param>
    public void ChangeRingRoad(bool state)
    {
        ringRoad = state;
        bezierFactory.ChangeRingRoad(ringRoad);
        ringRoadToggle.isOn = ringRoad;
    }

    /// <summary>
    /// Highlight the first checkpoint when the play is started
    /// </summary>
    public void StartPlaying()
    {
        if (allCheckpoints.Count > 0)
        {
            allCheckpoints[0].GetComponent<Outline>().enabled = true;
        }
    }

    /// <summary>
    /// Reset passed checkpoints
    /// </summary>
    public void ResetPassedCheckpoints()
    {
        for (int i = 0; i < allCheckpoints.Count; i++)
        {
            allCheckpoints[i].isPassed = false;
            allCheckpoints[i].GetComponent<Outline>().enabled = false;
        }
    }

    /// <summary>
    /// Insert new checkpoint at our checkpoints' list
    /// </summary>
    /// <param name="checkpoint">New checkpoint's info</param>
    /// <param name="index">New cheackpoint's index</param>
    private void InsertCheckpointAt(Checkpoint checkpoint, int index)
    {
        checkpoint.checkpointNumber = index;
        allCheckpoints.Insert(index, checkpoint);
        selectedObjectManager.DeselectObject();
    }

    /// <summary>
    /// The event which happens when the last checkpoint is passsed by player
    /// </summary>
    private void OnFinish()
    {
        if (ringRoad)
        {
            playerManager.currentPlayer.GetComponent<PlayerUI>().FinishLap();
            for (int i = 0; i < allCheckpoints.Count; i++) 
            {
                allCheckpoints[i].ResetPassed();
                playerManager.currentPlayer.GetComponent<PlayerUI>().ResetPassedCheckpoints();
            }
            allCheckpoints[^1].GetComponent<Outline>().enabled = false;
            allCheckpoints[0].GetComponent<Outline>().enabled = true;
        }
        else { playerManager.currentPlayer.GetComponent<PlayerWin>().Pause(); }
    }
}
