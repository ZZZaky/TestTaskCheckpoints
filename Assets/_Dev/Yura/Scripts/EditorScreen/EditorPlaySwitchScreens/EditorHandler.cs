using UnityEngine;
using Zenject;

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

    public void Activate()
    {
        SwitchEditingState(true);
        editorCanvas.SetActive(true);
        editorCamera.enabled = true;
        editorCameraController.enabled = true;
        editorAudioListener.enabled = true;
    }

    public void Deactivate()
    {
        SwitchEditingState(false);
        editorCanvas.SetActive(false);
        editorCamera.enabled = false;
        editorCameraController.enabled = false;
        editorAudioListener.enabled = false;
    }

    private void SwitchEditingState(bool state)
    {
        for (int i = 0; i < checkpointManager.allCheckpoints.Count; i++)
        {
            selectedObjectManager.DeselectObject();
            checkpointManager.allCheckpoints[i].GetComponent<CheckpointDrag>().enabled = state;
        }
    }
}
