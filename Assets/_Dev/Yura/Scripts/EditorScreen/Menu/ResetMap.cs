using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ResetMap : MonoBehaviour
{
    [Inject] CheckpointManager checkpointManager;

    public void ResetCheckpoints()
    {
        checkpointManager.ResetCheckpoints();
    }
}
