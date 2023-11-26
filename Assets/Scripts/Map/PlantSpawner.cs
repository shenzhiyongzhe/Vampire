using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> plantList;
    [SerializeField] List<Vector3> spawnList;
    [SerializeField] int spawnNumber;
    [SerializeField] Vector2 spawnSize;
    [SerializeField] Transform spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlant();
    }

    void SpawnPlant()
    {
        Vector2 randPos;
        int randIndex;
        for(int i = 0; i < spawnNumber; i++)
        {
            randPos.x = Random.Range(spawnPosition.position.x - 0.5 * spawnSize.x > 0 ? (float)(spawnPosition.position.x - 0.5 * spawnSize.x - 4) : (float)(spawnPosition.position.x - 0.5 * spawnSize.x + 4), (float)(spawnPosition.position.x + 0.5 * spawnSize.x));
            randPos.y = Random.Range(spawnPosition.position.y - 0.5 * spawnSize.y > 0 ? (float)(spawnPosition.position.x - 0.5 * spawnSize.y - 4) : (float)(spawnPosition.position.y - 0.5 * spawnSize.y + 4), (float)(spawnPosition.position.y + 0.5 * spawnSize.y));
            spawnList.Add(randPos);
            randIndex = Random.Range(0, plantList.Count);
            Instantiate(plantList[randIndex], spawnList[i], Quaternion.identity, transform);
        }
    }
}
