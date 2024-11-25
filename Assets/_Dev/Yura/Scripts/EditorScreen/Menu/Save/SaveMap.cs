using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class SaveMap : MonoBehaviour
{
    public GameObject saveUI;
    public TMP_InputField title;
    private bool isOn;

    [Inject] private MapHandler mapHandler;
    [Inject] private SavableMapData savableMapData;

    void Start()
    {
        isOn = false;
        saveUI.SetActive(isOn);
    }

    public void OnClickSave()
    {
        Time.timeScale = Time.timeScale == 1f ? 0f : 1f;
        isOn = !isOn;
        saveUI.SetActive(isOn);
    }

    public void SaveCurrentMap()
    {
        mapHandler.title = title.text;
        savableMapData.allMaps.AddNewMap(mapHandler.GetMap());
        title.text = "";
        OnClickSave();
    }

    public void CloseUI()
    {
        Time.timeScale = 1f;
        isOn = false;
        saveUI.SetActive(isOn);
    }

}
