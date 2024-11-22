using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

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

    public void SetSelectedCheckpoint(int index)
    {
        this.index = index;
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        isFinish = checkpointManager.allCheckpoints.Count - 1 == index ? true : false;
        isStart = index == 0;

        indexText.text = index.ToString();
        isStartText.text = isStart.ToString();
        isFinishText.text = isFinish.ToString();
    }

    public void CreateCheckpointAfter()
    {
        checkpointManager.CreateCheckpointAt(index + 1);
        UpdateInfo();
    }
    
    public void CreateCheckpointBefore()
    {
        checkpointManager.CreateCheckpointAt(index);
        UpdateInfo();
    }

    public void DeleteCheckpoint()
    {
        checkpointManager.DeleteCheckpointAt(index);
    }
}
