using UnityEngine;
using Zenject;

public class EditorPlayScreensHandler : MonoBehaviour
{
    [Inject] private EditorHandler editorCamera;
    [Inject] private PlayerHandler player;
    [Inject] private SelectedObjectManager selectedObjectManager;

    void Start()
    {
        SwitchToEditor();
    }

    public void SwitchToEditor()
    {
        editorCamera.Activate();
        player.Deactivate();
        selectedObjectManager.isOn = true;
    }

    public void SwitchToPlay()
    {
        editorCamera.Deactivate();
        player.Activate();
        selectedObjectManager.isOn = false;
    }
}
