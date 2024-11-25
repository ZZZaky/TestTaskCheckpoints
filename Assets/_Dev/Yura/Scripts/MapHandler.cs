using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MapHandler : MonoBehaviour
{
    public int id;
    public string title;

    [Inject] private CheckpointManager checkpointManager;
    [Inject] private PlayerManager playerManager;
    [Inject] private EditorPlayScreensHandler editorPlayScreensHandler;

    void Awake()
    {
        if (checkpointManager.allCheckpoints == null)
        {
            checkpointManager.allCheckpoints = new List<Checkpoint>();
        }
        else
        {
            checkpointManager.InitializeCheckpoints();
        }
        checkpointManager.ChangeRingRoad(false);

        if (playerManager.currentPlayer == null)
        {
            playerManager.CreatePlayer();
        }
    }

    public Map GetMap()
    {
        List<CheckpointData> checkpoints = new List<CheckpointData>();

        for (int i = 0; i < checkpointManager.allCheckpoints.Count; i ++)
        {
            checkpoints.Add(new CheckpointData(i, checkpointManager.allCheckpoints[i].transform));
        }

        return new Map(id, title, checkpoints, new PlayerData(playerManager.currentPlayer.transform), checkpointManager.ringRoad);
    }

    public void SetMap(Map map)
    {
        id = map.mapId;
        title = map.mapTitle;

        checkpointManager.ResetCheckpoints();
        for (int i = 0; i < map.checkpoints.Count; i ++)
        {
            checkpointManager.CreateCheckpointFromMap(map.checkpoints[i]);
        }
        playerManager.CreatePlayer(map.player);
        editorPlayScreensHandler.SwitchToEditor();
        checkpointManager.ChangeRingRoad(map.ringRoad);
    }
}
