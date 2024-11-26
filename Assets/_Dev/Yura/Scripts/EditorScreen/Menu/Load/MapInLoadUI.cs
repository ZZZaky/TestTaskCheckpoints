using TMPro;
using UnityEngine;
using Zenject;

/// <summary>
/// Map in Load UI
/// </summary>
public class MapInLoadUI : MonoBehaviour
{
    public TextMeshProUGUI id;
    public TextMeshProUGUI title;

    public Map map;
    [Inject] MapHandler mapHandler;
    [Inject] SavableMapData savableMapData;

    /// <summary>
    /// Saving all info into this map from map sample
    /// </summary>
    /// <param name="loadingMap">Map sample</param>
    public void Initialization(Map loadingMap)
    {
        map = new Map(loadingMap);
        id.text = map.mapId.ToString();
        title.text = map.mapTitle;
    }

    /// <summary>
    /// Load map in scene from this map
    /// </summary>
    public void LoadMap()
    {
        mapHandler.SetMap(map);
    }

    /// <summary>
    /// Delete this map from saved maps
    /// </summary>
    public void DeleteMap()
    {
        savableMapData.allMaps.DeleteMapAt(map.mapTitle);
        Destroy(gameObject);
    }
}
