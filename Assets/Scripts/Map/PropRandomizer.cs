using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> propSpawnPoints;
    [SerializeField] private List<GameObject> propPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnProps()
    {
        foreach(GameObject sp in propSpawnPoints) 
        {
            int rand = Random.Range(0, propSpawnPoints.Count -1 );
            Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity, sp.transform);
        }
    }
}
