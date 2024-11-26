using UnityEngine;
using Zenject;

/// <summary>
/// Editor handler
/// </summary>
public class EditorHandler : MonoBehaviour
{
    [SerializeField] private GameObject editorCanvas;

    private Camera editorCamera;
    private CameraController editorCameraController;
    private AudioListener editorAudioListener;
    [Inject] private CheckpointManager checkpointManager;
    [Inject] private SelectedObjectManager selectedObjectManager;

    void Awake()
    {
        editorCamera = GetComponent<Camera>();
        editorAudioListener = GetComponent<AudioListener>();
        editorCameraController = GetComponentInParent<CameraController>();
    }

    /// <summary>
    /// Activate editor
    /// </summary>
    public void Activate()
    {
        SwitchEditingState(true);
        editorCanvas.SetActive(true);
        editorCamera.enabled = true;
        editorCameraController.enabled = true;
        editorAudioListener.enabled = true;
    }

    /// <summary>
    /// Deactivate editor
    /// </summary>
    public void Deactivate()
    {
        SwitchEditingState(false);
        editorCanvas.SetActive(false);
        editorCamera.enabled = false;
        editorCameraController.enabled = false;
        editorAudioListener.enabled = false;
    }

    /// <summary>
    /// Switch editor's state
    /// </summary>
    /// <param name="state">New editor's state</param>
    private void SwitchEditingState(bool state)
    {
        for (int i = 0; i < checkpointManager.allCheckpoints.Count; i++)
        {
            selectedObjectManager.DeselectObject();
            checkpointManager.allCheckpoints[i].GetComponent<CheckpointDrag>().enabled = state;
        }
    }
}
