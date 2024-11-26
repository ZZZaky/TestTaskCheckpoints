using UnityEngine;
using Zenject;

/// <summary>
/// Switcher between editor and play
/// </summary>
public class EditorPlayScreensHandler : MonoBehaviour
{
    [Inject] private EditorHandler editor;
    [Inject] private PlayerManager playerManager;
    [Inject] private CheckpointManager checkpointManager;

    void Start()
    {
        SwitchToEditor();
    }

    /// <summary>
    /// Switch to editor
    /// </summary>
    public void SwitchToEditor()
    {
        checkpointManager.ResetPassedCheckpoints();
        playerManager.currentPlayer.GetComponent<CarHandler>().Deactivate();
        editor.Activate();
    }

    /// <summary>
    /// Switch to play
    /// </summary>
    public void SwitchToPlay()
    {
        checkpointManager.ResetPassedCheckpoints();
        checkpointManager.StartPlaying();
        editor.Deactivate();
        playerManager.currentPlayer.GetComponent<CarHandler>().Activate();
    }

    /// <summary>
    /// Restart play
    /// </summary>
    public void RestartPlay()
    {
        checkpointManager.ResetPassedCheckpoints();
        playerManager.currentPlayer.GetComponent<CarHandler>().Deactivate();
        editor.Activate();
        editor.Deactivate();
        playerManager.currentPlayer.GetComponent<CarHandler>().Activate();
    }
}
