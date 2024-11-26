using UnityEngine;
using Zenject;

/// <summary>
/// Reset map in editor
/// </summary>
public class ResetMap : MonoBehaviour
{
    [Inject] CheckpointManager checkpointManager;
    [Inject] PlayerManager playerManager;
    [Inject] EditorPlayScreensHandler editorPlayScreensHandler;

    /// <summary>
    /// Reset current map in scene
    /// </summary>
    public void ResetCheckpoints()
    {
        checkpointManager.ResetCheckpoints();
        playerManager.CreatePlayer();
        editorPlayScreensHandler.SwitchToEditor();
    }
}
