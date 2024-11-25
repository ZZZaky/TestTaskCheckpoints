using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject currentPlayer;

    [Inject] private DiContainer diContainer;

    public void CreatePlayer()
    {
        if (currentPlayer != null) { Destroy(currentPlayer); }
        currentPlayer = diContainer.InstantiatePrefab(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity, null);
    }

    public void CreatePlayer(PlayerData newPlayer)
    {
        if (currentPlayer != null) { Destroy(currentPlayer); }
        currentPlayer = diContainer.InstantiatePrefab(playerPrefab,
                new Vector3(newPlayer.transform.position.x, newPlayer.transform.position.y, newPlayer.transform.position.z),
                new Quaternion(newPlayer.transform.rotation.x, newPlayer.transform.rotation.y, newPlayer.transform.rotation.z, newPlayer.transform.rotation.w),
                null);
    }
}
