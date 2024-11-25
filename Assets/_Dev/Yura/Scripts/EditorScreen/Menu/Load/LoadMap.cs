using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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

    public void OnClickLoad()
    {
        Time.timeScale = Time.timeScale == 1f ? 0f : 1f;
        isOn = !isOn;
        loadUI.SetActive(isOn);
        if (isOn) { LoadAllMaps(); }
    }

    public void CloseUI()
    {
        Time.timeScale = 1f;
        isOn = false;
        loadUI.SetActive(isOn);
    }

    private void LoadAllMaps()
    {
        loadMapShowcase.DeleteMapsShowcase();
        foreach (Map map in savableMapData.allMaps.maps)
        {
            loadMapShowcase.CreateMapShowcase(map);
        }
    }
}
