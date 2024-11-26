using System.IO;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All current maps' data
/// </summary>
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

    /// <summary>
    /// Save all maps to Json
    /// </summary>
    public void SaveToJson()
    {
        AllMaps toSave = new AllMaps(allMaps);
        string data = JsonUtility.ToJson(toSave, true);
        File.WriteAllText(filePath, data);
    }

    /// <summary>
    /// Load all maps from Json
    /// </summary>
    public void LoadFromJson()
    {
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            allMaps = new AllMaps(JsonUtility.FromJson<AllMaps>(data));
        }
    }
}

/// <summary>
/// All maps' data
/// </summary>
[System.Serializable]
public class AllMaps
{
    public List<Map> maps;

    /// <summary>
    /// Default constructor
    /// </summary>
    public AllMaps() { maps = new List<Map>(); }

    /// <summary>
    /// Constructor with all maps' sample
    /// </summary>
    /// <param name="copy">All maps' sample</param>
    public AllMaps(AllMaps copy)
    {
        maps = new List<Map>();
        foreach (Map map in copy.maps)
        {
            maps.Add(new Map(map));
        }
    }

    /// <summary>
    /// Create new map
    /// </summary>
    /// <param name="newMap">New <see cref="Map"/></param>
    /// <returns>If the new map was added</returns>
    public bool AddNewMap(Map newMap)
    {
        bool unique = true;
        // Unique by title
        foreach (Map map in maps)
        {
            if (map.mapTitle == newMap.mapTitle) { unique = false; break; }
        }

        // If newMap isn't unique -> not new, we don't add it
        if (unique)
        {
            newMap.mapId = maps.Count;
            maps.Add(new Map(newMap));
        }
        return unique;
    }

    /// <summary>
    /// Delete map
    /// </summary>
    /// <param name="deleteTitle">Deleting map's title</param>
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

/// <summary>
/// Map's data
/// </summary>
[System.Serializable]
public class Map
{
    public string mapTitle;
    public int mapId;
    public List<CheckpointData> checkpoints;
    public PlayerData player;
    public bool ringRoad;

    /// <summary>
    /// Default constructor
    /// </summary>
    public Map() 
    {
        checkpoints = new List<CheckpointData>();
        player = new PlayerData();
    }

    /// <summary>
    /// Constructor with map's sample
    /// </summary>
    /// <param name="copy">Map's sample</param>
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

    /// <summary>
    /// Constructor with map's info
    /// </summary>
    /// <param name="copyMapId">Map's id</param>
    /// <param name="copyMapTitle">Map's title</param>
    /// <param name="copyCheckpoints">Map's checkpoint's info</param>
    /// <param name="copyPlayer">Map's player info</param>
    /// <param name="copyRingRoad">Map's ring road state</param>
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
}

/// <summary>
/// Checkpoint's data
/// </summary>
[System.Serializable]
public class CheckpointData
{
    public int checkpointIndex;
    public TransformData transform;

    /// <summary>
    /// Default constructor
    /// </summary>
    public CheckpointData() {}

    /// <summary>
    /// Constructor with checkpoint's sample
    /// </summary>
    /// <param name="copy">Checkpoint's sample</param>
    public CheckpointData(CheckpointData copy)
    {
        checkpointIndex = copy.checkpointIndex;
        transform = new TransformData(copy.transform);
    }

    /// <summary>
    /// Constructor with checkpoint's info
    /// </summary>
    /// <param name="copyCheckpointIndex">Checkpoint's index</param>
    /// <param name="copyTransform">Checkpoint's transform</param>
    public CheckpointData(int copyCheckpointIndex, Transform copyTransform)
    {
        checkpointIndex = copyCheckpointIndex;
        transform = new TransformData(copyTransform);
    }
}

/// <summary>
/// Player's data
/// </summary>
[System.Serializable]
public class PlayerData
{
    public TransformData transform;

    /// <summary>
    /// Default constructor
    /// </summary>
    public PlayerData() { }

    /// <summary>
    /// Constructor with player's sample
    /// </summary>
    /// <param name="copy">Player's sample</param>
    public PlayerData(PlayerData copy)
    {
        transform = new TransformData(copy.transform);
    }

    /// <summary>
    /// Constructor with player's info
    /// </summary>
    /// <param name="copyTransform">Player's info</param>
    public PlayerData(Transform copyTransform)
    {
        transform = new TransformData(copyTransform);
    }
}

/// <summary>
/// Position and rotation
/// </summary>
[System.Serializable]
public class TransformData
{
    public Vector3 position;
    public Quaternion rotation;

    /// <summary>
    /// Default constructor
    /// </summary>
    public TransformData() {}

    /// <summary>
    /// Constructor with transform's sample
    /// </summary>
    /// <param name="copy">Transform's sample</param>
    public TransformData(Transform copy)
    {
        position = copy.position;
        rotation = copy.rotation;
    }

    /// <summary>
    /// Constructor with position's and rotation's sample
    /// </summary>
    /// <param name="copy">Position's and rotation's sample</param>
    public TransformData(TransformData copy)
    {
        position = copy.position;
        rotation = copy.rotation;
    }
}
