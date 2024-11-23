using UnityEngine;
using Zenject;

public class EditorPlayScreensHandler : MonoBehaviour
{
    [Inject] private EditorHandler editor;
    [Inject] private PlayerHandler player;

    void Start()
    {
        SwitchToEditor();
    }

    public void SwitchToEditor()
    {
        editor.Activate();
        player.Deactivate();
    }

    public void SwitchToPlay()
    {
        editor.Deactivate();
        player.Activate();
    }
}
