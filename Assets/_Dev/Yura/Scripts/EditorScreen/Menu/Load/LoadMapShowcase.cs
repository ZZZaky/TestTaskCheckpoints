using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Handler for all loaded maps in Load UI
/// </summary>
public class LoadMapShowcase : MonoBehaviour
{
    public GameObject mapShowcasePrefab;

    public List<GameObject> mapsShowcase;
    [Inject] private DiContainer diContainer;

    void Awake()
    {
        mapsShowcase = new List<GameObject>();
    }

    /// <summary>
    /// Create map in Load UI based on map sample
    /// </summary>
    /// <param name="map">Map sample</param>
    public void CreateMapShowcase(Map map)
    {
        GameObject newCheckpoint = diContainer.InstantiatePrefab(mapShowcasePrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), transform);
        mapsShowcase.Add(newCheckpoint);
        mapsShowcase[^1].GetComponent<MapInLoadUI>().Initialization(map);
    }

    /// <summary>
    /// Clear all maps in Load UI
    /// </summary>
    public void DeleteMapsShowcase()
    {
        foreach (GameObject checkpoint in mapsShowcase)
        {
            Destroy(checkpoint);
        }
    }
}
