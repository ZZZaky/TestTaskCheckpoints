using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && !isPassed)
        {
            checkpointManager.OnEnterCheckpoint(checkpointNumber);
        }
    }

    public void CheckpointPassed()
    {
        isPassed = true;
    }

    public void ResetPassed()
    {
        isPassed = false;
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
