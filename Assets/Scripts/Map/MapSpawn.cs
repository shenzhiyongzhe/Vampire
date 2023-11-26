using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> terrainChunk;
    [SerializeField] private Transform player;
    [SerializeField] private float checkRadius;

    private Vector3 noTerrainPosition;
    [SerializeField] private LayerMask terrainMask;
    private PlayerMove playerMove;
    public GameObject currentChunk;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject lastChunk;
    public float maxOpDist;
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }
        if(playerMove.moveDirection.x > 0 && playerMove.moveDirection.y == 0) // right
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkRadius, terrainMask)){
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if (playerMove.moveDirection.x < 0 && playerMove.moveDirection.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (playerMove.moveDirection.x == 0 && playerMove.moveDirection.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (playerMove.moveDirection.x == 0 && playerMove.moveDirection.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }

    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunk.Count -1);
        lastChunk = Instantiate(terrainChunk[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(lastChunk);
    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;   //Check every 1 second to save cost, change this value to lower to check more times
        }
        else
        {
            return;
        }
        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if(opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
