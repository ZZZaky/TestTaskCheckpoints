using UnityEngine;
using Zenject;

/// <summary>
/// Player manager
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject currentPlayer;

    [Inject] private DiContainer diContainer;

    /// <summary>
    /// Create new player
    /// </summary>
    public void CreatePlayer()
    {
        if (currentPlayer != null) { Destroy(currentPlayer); }
        currentPlayer = diContainer.InstantiatePrefab(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity, null);
    }

    /// <summary>
    /// Create new player using specific <see cref="PlayerData"/>
    /// </summary>
    /// <param name="newPlayer">New player's <see cref="PlayerData"/></param>
    public void CreatePlayer(PlayerData newPlayer)
    {
        if (currentPlayer != null) { Destroy(currentPlayer); }
        currentPlayer = diContainer.InstantiatePrefab(playerPrefab,
                new Vector3(newPlayer.transform.position.x, newPlayer.transform.position.y, newPlayer.transform.position.z),
                new Quaternion(newPlayer.transform.rotation.x, newPlayer.transform.rotation.y, newPlayer.transform.rotation.z, newPlayer.transform.rotation.w),
                null);
    }
}
