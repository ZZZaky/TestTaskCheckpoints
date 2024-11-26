using UnityEngine;
using UnityEngine.UI;
using Zenject;

/// <summary>
/// Switch ring road's state in editor
/// </summary>
public class RingRoadSwitcher : MonoBehaviour
{
    [Inject] CheckpointManager checkpointManager;
    private Toggle switcher;

    void Awake()
    {
        switcher = GetComponent<Toggle>();
    }

    /// <summary>
    /// Event for switching ring road's state
    /// </summary>
    public void SwitchRingRoad()
    {
        checkpointManager.ChangeRingRoad(switcher.isOn);
    }
}
