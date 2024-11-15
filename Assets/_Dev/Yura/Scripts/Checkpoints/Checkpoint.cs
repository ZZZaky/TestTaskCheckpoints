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

    [Inject] private CheckpointManager checkpointManager;
    public bool isPassed; 

    void Start()
    {
        isPassed = false;
    }

    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && !isPassed)
        {
            Debug.Log("Checkpoint passed");
            checkpointManager.OnEnterCheckpoint(checkpointNumber);
        }
    }

    public void CheckpointPassed()
    {
        isPassed = true;
        Debug.Log($"{checkpointNumber} done");
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
