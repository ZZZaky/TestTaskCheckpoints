using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

/// <summary>
/// Objects' select manager
/// </summary>
public class SelectedObjectManager : MonoBehaviour
{
    public GameObject selectedObject;

    [Inject] private CheckpointEditorHandler checkpointEditorHandler;

    void Start()
    {
        selectedObject = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedObject != null)
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

    /// <summary>
    /// Select specific player
    /// </summary>
    /// <param name="player">Specific player</param>
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

    /// <summary>
    /// Select specific checkpoint
    /// </summary>
    /// <param name="checkpoint">Specific checkpoint</param>
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

    /// <summary>
    /// Deselect current object
    /// </summary>
    public void DeselectObject()
    {
        if (selectedObject != null)
        {
            selectedObject.GetComponent<Outline>().enabled = false;
            selectedObject = null;
            checkpointEditorHandler.gameObject.SetActive(false);
        }
    }
}
