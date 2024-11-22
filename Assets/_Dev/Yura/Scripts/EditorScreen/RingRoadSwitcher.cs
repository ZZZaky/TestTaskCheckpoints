using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RingRoadSwitcher : MonoBehaviour
{
    [Inject] CheckpointManager checkpointManager;
    private Toggle switcher;

    void Start()
    {
        switcher = GetComponent<Toggle>();
        SwitchRingRoad();
    }

    public void SwitchRingRoad()
    {
        checkpointManager.ChangeRingRoad(switcher.isOn);
    }
}
