using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapSpawn ms;
    public GameObject targetMap;
    // Start is called before the first frame update
    void Start()
    {
        ms = FindObjectOfType<MapSpawn>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ms.currentChunk = targetMap;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && ms.currentChunk == targetMap) 
        {
            ms.currentChunk = null;
        }

    }
}
