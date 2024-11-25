using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class MapInLoadUI : MonoBehaviour
{
    public TextMeshProUGUI id;
    public TextMeshProUGUI title;

    public Map map;
    [Inject] MapHandler mapHandler;
    [Inject] SavableMapData savableMapData;

    public void Initialization(Map loadingMap)
    {
        map = new Map(loadingMap);
        id.text = map.mapId.ToString();
        title.text = map.mapTitle;
    }

    public void LoadMap()
    {
        mapHandler.SetMap(map);
    }

    public void DeleteMap()
    {
        savableMapData.allMaps.DeleteMapAt(map.mapTitle);
        Destroy(gameObject);
    }
}
