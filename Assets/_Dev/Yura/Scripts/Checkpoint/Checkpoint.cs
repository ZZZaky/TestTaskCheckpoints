using UnityEngine;
using Zenject;


/// <summary>
/// Checkpoint handler
/// </summary>
public class Checkpoint : MonoBehaviour
{
    public int checkpointNumber;
    public bool isPassed; 

    [Inject] private CheckpointManager checkpointManager;

    void Start()
    {
        isPassed = false;
    }

    /// <summary>
    /// Try to check if the player is entering this checkpoint
    /// </summary>
    /// <param name="player"></param>
    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && !isPassed)
        {
            checkpointManager.OnEnterCheckpoint(checkpointNumber);
        }
    }

    /// <summary>
    /// Set the state of checkpoint to passed
    /// </summary>
    public void CheckpointPassed()
    {
        isPassed = true;
    }

    /// <summary>
    /// Reset the state of checkpoint to not passed
    /// </summary>
    public void ResetPassed()
    {
        isPassed = false;
    }

    /// <summary>
    /// Delete this checkpoint
    /// </summary>
    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
