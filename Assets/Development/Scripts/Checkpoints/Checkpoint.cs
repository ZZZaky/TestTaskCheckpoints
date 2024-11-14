using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

// Checkpoint
//
public class Checkpoint : MonoBehaviour
{
    public int checkpointNumber;

    [Inject] private CheckpointManager checkpointManager;
    public bool checkpointPassed; 

    void Start()
    {
        checkpointPassed = false;
    }

    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && !checkpointPassed)
        {
            Debug.Log("Checkpoint passed");
            checkpointManager.OnEnterCheckpoint(checkpointNumber);
        }
    }

    public void CheckpointPassed()
    {
        checkpointPassed = true;
        Debug.Log($"{checkpointNumber} done");
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
