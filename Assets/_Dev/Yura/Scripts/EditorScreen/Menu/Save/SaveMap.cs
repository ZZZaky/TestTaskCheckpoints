using TMPro;
using UnityEngine;
using Zenject;

/// <summary>
/// Save map in editor
/// </summary>
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

    /// <summary>
    /// The event which happens on Click
    /// </summary>
    public void OnClickSave()
    {
        Time.timeScale = Time.timeScale == 1f ? 0f : 1f;
        isOn = !isOn;
        saveUI.SetActive(isOn);
    }

    /// <summary>
    /// Close Load UI
    /// </summary>
    public void CloseUI()
    {
        Time.timeScale = 1f;
        isOn = false;
        saveUI.SetActive(isOn);
    }

    /// <summary>
    /// Save current map into saved maps
    /// </summary>
    public void SaveCurrentMap()
    {
        mapHandler.title = title.text;
        savableMapData.allMaps.AddNewMap(mapHandler.GetMap());
        title.text = "";
        OnClickSave();
    }
}
