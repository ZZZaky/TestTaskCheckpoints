using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SelectedCheckpointManager : MonoBehaviour
{
    public GameObject selectedCheckpoint;

    [Inject] CheckpointEditorHandler checkpointEditorHandler;

    void Start()
    {
        selectedCheckpoint = null;
    }

    public void SelectCheckpoint(GameObject checkpoint)
    {
        if (selectedCheckpoint == null)
        {
            selectedCheckpoint = checkpoint;
            checkpoint.GetComponent<Outline>().enabled = true;
            checkpointEditorHandler.gameObject.SetActive(true);
        }
        else if (selectedCheckpoint != checkpoint)
        {
            selectedCheckpoint.GetComponent<Outline>().enabled = false;
            selectedCheckpoint = checkpoint;
            checkpoint.GetComponent<Outline>().enabled = true;
        }

        checkpointEditorHandler.SetSelectedCheckpoint(checkpoint.GetComponent<Checkpoint>().checkpointNumber);
    }
}
