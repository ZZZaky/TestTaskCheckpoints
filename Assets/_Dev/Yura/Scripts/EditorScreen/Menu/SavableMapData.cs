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

    public bool AddNewMap(Map newMap)
    {
        bool unique = true;
        foreach (Map map in maps)
        {
            if (map.mapTitle == newMap.mapTitle) { unique = false; break; }
        }

        if (unique)
        {
            newMap.mapId = maps.Count;
            maps.Add(new Map(newMap));
        }
        return unique;
    }

    public void DeleteMapAt(string deleteTitle)
    {
        int deleteId = maps.Count;
        for (int i = 0; i < maps.Count; i++)
        {
            if (maps[i].mapTitle == deleteTitle)
            {
                deleteId = i;
                maps.RemoveAt(deleteId);
                break;
            }
        }

        for (int i = deleteId; i < maps.Count; i++)
        {
            maps[i].mapId -= 1;
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
    public bool ringRoad;

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
        ringRoad = copy.ringRoad;
    }

    public Map(int copyMapId, string copyMapTitle, List<CheckpointData> copyCheckpoints, PlayerData copyPlayer, bool copyRingRoad)
    {
        mapId = copyMapId;
        mapTitle = copyMapTitle;

        checkpoints = new List<CheckpointData>();

        foreach (CheckpointData checkpoint in copyCheckpoints)
        {
            checkpoints.Add(new CheckpointData(checkpoint));
        }

        player = new PlayerData(copyPlayer);
        ringRoad = copyRingRoad;
    }

    override
    public string ToString()
    {
        string returns = "";
        returns += mapId + " ";

        foreach (CheckpointData checkpoint in checkpoints)
        {
            returns += checkpoint.checkpointIndex + ": [" + checkpoint.transform.position + "] ";
        }

        return returns;
    }
}

[System.Serializable]
public class CheckpointData
{
    public int checkpointIndex;
    public TransformData transform;

    public CheckpointData() {}

    public CheckpointData(CheckpointData copy)
    {
        checkpointIndex = copy.checkpointIndex;
        transform = new TransformData(copy.transform);
    }

    public CheckpointData(int copyCheckpointIndex, Transform copyTransform)
    {
        checkpointIndex = copyCheckpointIndex;
        transform = new TransformData(copyTransform);
    }
}

[System.Serializable]
public class PlayerData
{
    public TransformData transform;

    public PlayerData() { }

    public PlayerData(PlayerData copy)
    {
        transform = new TransformData(copy.transform);
    }

    public PlayerData(Transform copyTransform)
    {
        transform = new TransformData(copyTransform);
    }
}

[System.Serializable]
public class TransformData
{
    public Vector3 position;
    public Quaternion rotation;

    public TransformData() {}

    public TransformData(Transform copy)
    {
        position = copy.position;
        rotation = copy.rotation;
    }

    public TransformData(TransformData copy)
    {
        position = copy.position;
        rotation = copy.rotation;
    }
}
