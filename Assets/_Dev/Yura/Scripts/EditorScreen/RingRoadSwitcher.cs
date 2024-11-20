using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RingRoadSwitcher : MonoBehaviour
{
    [Inject] CheckpointManager checkpointManager;
    public Toggle switcher;

    void Start()
    {
        SwitchRingRoad();
    }

    public void SwitchRingRoad()
    {
        checkpointManager.ChangeRingRoad(switcher.isOn);
    }
}
