using System.IO;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavableMapData : MonoBehaviour
{
    public AllMaps allMaps;

    private string filePath;

    void Awake()
    {
        filePath = Application.persistentDataPath + "/SavedMaps.json";
        allMaps = new AllMaps();

        Debug.Log($"Path for all saved maps: [{filePath}]");
        LoadFromJson();
    }

    void Update()
    {
        SaveToJson();
    }

    public void SaveToJson()
    {
        AllMaps toSave = new AllMaps(allMaps);
        string data = JsonUtility.ToJson(toSave, true);
        File.WriteAllText(filePath, data);
    }

    public void LoadFromJson()
    {
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            allMaps = new AllMaps(JsonUtility.FromJson<AllMaps>(data));
        }
    }
}

[System.Serializable]
public class AllMaps
{
    public List<Map> maps;

    public AllMaps() { maps = new List<Map>(); }
    public AllMaps(AllMaps copy)
    {
        maps = new List<Map>();
        foreach (Map map in copy.maps)
        {
            maps.Add(new Map(map));
        }
    }
}

[System.Serializable]
public class Map
{
    public string mapTitle;
    public int mapId;
    public List<CheckpointData> checkpoints;
    public PlayerData player;

    public Map() 
    {
        checkpoints = new List<CheckpointData>();
        player = new PlayerData();
    }
    public Map(Map copy)
    {
        mapTitle = copy.mapTitle;
        mapId = copy.mapId;
        checkpoints = new List<CheckpointData>();
        foreach (CheckpointData checkpoint in copy.checkpoints)
        {
            checkpoints.Add(new CheckpointData(checkpoint));
        }
        player = new PlayerData(copy.player);
    }
}

[System.Serializable]
public class CheckpointData
{
    public int checkpointIndex;
    public Transform transform;

    public CheckpointData() {}
    public CheckpointData(CheckpointData copy)
    {
        checkpointIndex = copy.checkpointIndex;
        transform.position = copy.transform.position;
        transform.rotation = copy.transform.rotation;
    }
}

[System.Serializable]
public class PlayerData
{
    public Transform transform;

    public PlayerData() { }
    public PlayerData(PlayerData copy)
    {
        transform.position = copy.transform.position;
        transform.rotation = copy.transform.rotation;
    }
}
