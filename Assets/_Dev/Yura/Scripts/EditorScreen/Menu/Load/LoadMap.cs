using UnityEngine;
using Zenject;

/// <summary>
/// Load map in editor
/// </summary>
public class LoadMap : MonoBehaviour
{
    public GameObject loadUI;
    public LoadMapShowcase loadMapShowcase;
    private bool isOn;

    [Inject] private SavableMapData savableMapData;

    void Start()
    {
        isOn = false;
        loadUI.SetActive(isOn);
    }

    /// <summary>
    /// The event which happens on Click
    /// </summary>
    public void OnClickLoad()
    {
        Time.timeScale = Time.timeScale == 1f ? 0f : 1f;
        isOn = !isOn;
        loadUI.SetActive(isOn);
        if (isOn) { LoadAllMaps(); }
    }

    /// <summary>
    /// Close Load UI
    /// </summary>
    public void CloseUI()
    {
        Time.timeScale = 1f;
        isOn = false;
        loadUI.SetActive(isOn);
    }

    /// <summary>
    /// Load all maps for Load UI
    /// </summary>
    private void LoadAllMaps()
    {
        loadMapShowcase.DeleteMapsShowcase();
        foreach (Map map in savableMapData.allMaps.maps)
        {
            loadMapShowcase.CreateMapShowcase(map);
        }
    }
}
