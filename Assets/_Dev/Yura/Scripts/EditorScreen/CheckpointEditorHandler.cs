using TMPro;
using UnityEngine;
using Zenject;

/// <summary>
/// UI for editing checkpoint in editor
/// </summary>
public class CheckpointEditorHandler : MonoBehaviour
{
    public TextMeshProUGUI indexText;
    public TextMeshProUGUI isStartText;
    public TextMeshProUGUI isFinishText;

    public int index;
    public bool isStart;
    public bool isFinish;

    [Inject] private CheckpointManager checkpointManager;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Choosing specific checkpoint
    /// </summary>
    /// <param name="index">Checkpoint's index</param>
    public void SetSelectedCheckpoint(int index)
    {
        this.index = index;
        UpdateInfo();
    }

    /// <summary>
    /// Update editing checkpoint's info
    /// </summary>
    public void UpdateInfo()
    {
        isFinish = checkpointManager.allCheckpoints.Count - 1 == index ? true : false;
        isStart = index == 0;

        indexText.text = index.ToString();
        isStartText.text = isStart.ToString();
        isFinishText.text = isFinish.ToString();
    }

    /// <summary>
    /// The event for creating new checkpoint after editing one
    /// </summary>
    public void CreateCheckpointAfter()
    {
        checkpointManager.CreateCheckpointAt(index + 1);
        UpdateInfo();
    }

    /// <summary>
    /// The event for creating new checkpoint before editing one
    /// </summary>
    public void CreateCheckpointBefore()
    {
        checkpointManager.CreateCheckpointAt(index);
        UpdateInfo();
    }

    /// <summary>
    /// The event for deleting editing checkpoint
    /// </summary>
    public void DeleteCheckpoint()
    {
        checkpointManager.DeleteCheckpointAt(index);
    }
}
