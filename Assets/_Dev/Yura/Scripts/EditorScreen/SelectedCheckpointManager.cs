using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SelectedCheckpointManager : MonoBehaviour
{
    public GameObject selectedCheckpoint;

    [Inject] private CheckpointEditorHandler checkpointEditorHandler;

    void Start()
    {
        selectedCheckpoint = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit) || hit.collider.tag != "Checkpoint") 
            {
                selectedCheckpoint.GetComponent<Outline>().enabled = false;
                selectedCheckpoint = null;
                checkpointEditorHandler.gameObject.SetActive(false);
            }
        }
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
