using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RingRoadSwitcher : MonoBehaviour
{
    [Inject] CheckpointManager checkpointManager;
    private Toggle switcher;

    void Awake()
    {
        switcher = GetComponent<Toggle>();
    }

    public void SwitchRingRoad()
    {
        checkpointManager.ChangeRingRoad(switcher.isOn);
    }
}
