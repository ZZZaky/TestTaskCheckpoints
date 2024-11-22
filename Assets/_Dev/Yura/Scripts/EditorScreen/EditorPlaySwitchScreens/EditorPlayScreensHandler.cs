using UnityEngine;
using Zenject;

public class EditorPlayScreensHandler : MonoBehaviour
{
    [Inject] private EditorHandler editorCamera;
    [Inject] private PlayerHandler player;

    void Start()
    {
        SwitchToEditor();
    }

    public void SwitchToEditor()
    {
        editorCamera.Activate();
        player.Deactivate();
    }

    public void SwitchToPlay()
    {
        editorCamera.Deactivate();
        player.Activate();
    }
}
