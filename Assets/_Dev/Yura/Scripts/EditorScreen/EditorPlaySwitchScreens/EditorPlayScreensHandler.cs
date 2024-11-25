using UnityEngine;
using Zenject;

public class EditorPlayScreensHandler : MonoBehaviour
{
    [Inject] private EditorHandler editor;
    [Inject] private PlayerManager playerManager;
    [Inject] private CheckpointManager checkpointManager;

    void Start()
    {
        SwitchToEditor();
    }

    public void SwitchToEditor()
    {
        checkpointManager.ResetPassedCheckpoints();
        playerManager.currentPlayer.GetComponent<PlayerHandler>().Deactivate();
        editor.Activate();
    }

    public void SwitchToPlay()
    {
        checkpointManager.ResetPassedCheckpoints();
        editor.Deactivate();
        playerManager.currentPlayer.GetComponent<PlayerHandler>().Activate();
    }

    public void RestartPlay()
    {
        checkpointManager.ResetPassedCheckpoints();
        playerManager.currentPlayer.GetComponent<PlayerHandler>().Deactivate();
        editor.Activate();
        editor.Deactivate();
        playerManager.currentPlayer.GetComponent<PlayerHandler>().Activate();
    }
}
