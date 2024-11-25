using UnityEngine;
using Zenject;

public class EditorPlayScreensHandler : MonoBehaviour
{
    [Inject] private EditorHandler editor;
    [Inject] private PlayerManager playerManager;

    void Start()
    {
        SwitchToEditor();
    }

    public void SwitchToEditor()
    {
        editor.Activate();
        playerManager.currentPlayer.GetComponent<PlayerHandler>().Deactivate();
    }

    public void SwitchToPlay()
    {
        editor.Deactivate();
        playerManager.currentPlayer.GetComponent<PlayerHandler>().Activate();
    }
}
