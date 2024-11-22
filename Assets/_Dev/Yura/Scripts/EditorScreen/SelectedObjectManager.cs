using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class SelectedObjectManager : MonoBehaviour
{
    public GameObject selectedObject;
    public bool isOn;

    [Inject] private CheckpointEditorHandler checkpointEditorHandler;

    void Start()
    {
        selectedObject = null;
        isOn = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedObject != null && isOn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit) && !EventSystem.current.IsPointerOverGameObject()) 
            {
                selectedObject.GetComponent<Outline>().enabled = false;
                selectedObject = null;
                checkpointEditorHandler.gameObject.SetActive(false);
            }
        }
    }

    public void SelectPlayer(GameObject player)
    {
        if (selectedObject == null)
        {
            selectedObject = player;
            player.GetComponent<Outline>().enabled = true;
        }
        else if (selectedObject != player) 
        {
            selectedObject.GetComponent<Outline>().enabled = false;
            selectedObject = player;
            player.GetComponent<Outline>().enabled = true;
        }

        checkpointEditorHandler.gameObject.SetActive(false);
    }

    public void SelectCheckpoint(GameObject checkpoint)
    {
        if (selectedObject == null)
        {
            selectedObject = checkpoint;
            checkpoint.GetComponent<Outline>().enabled = true;
            checkpointEditorHandler.gameObject.SetActive(true);
        }
        else if (selectedObject != checkpoint)
        {
            selectedObject.GetComponent<Outline>().enabled = false;
            selectedObject = checkpoint;
            checkpoint.GetComponent<Outline>().enabled = true;
        }

        checkpointEditorHandler.SetSelectedCheckpoint(checkpoint.GetComponent<Checkpoint>().checkpointNumber);
    }

    public void DeselectObject()
    {
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
        checkpointEditorHandler.gameObject.SetActive(false);
    }
}
