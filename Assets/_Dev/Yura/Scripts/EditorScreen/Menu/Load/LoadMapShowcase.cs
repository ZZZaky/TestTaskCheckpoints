using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LoadMapShowcase : MonoBehaviour
{
    public GameObject mapShowcasePrefab;

    public List<GameObject> mapsShowcase;
    [Inject] private DiContainer diContainer;

    void Awake()
    {
        mapsShowcase = new List<GameObject>();
    }

    public void CreateMapShowcase(Map map)
    {
        GameObject newCheckpoint = diContainer.InstantiatePrefab(mapShowcasePrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), transform);
        mapsShowcase.Add(newCheckpoint);
        mapsShowcase[^1].GetComponent<MapInLoadUI>().Initialization(map);
    }

    public void DeleteMapsShowcase()
    {
        foreach (GameObject checkpoint in mapsShowcase)
        {
            Destroy(checkpoint);
        }
    }
}
