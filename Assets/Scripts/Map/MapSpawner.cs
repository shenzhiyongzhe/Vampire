using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField] GameObject mapChunk;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for(int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    default:
                        break;
                    case 0: GameObject map_up = Instantiate(mapChunk, transform.position + new Vector3(0, 30, 0), Quaternion.identity); map_up.name = $"up{i}"; break;
                    case 1: GameObject map_down = Instantiate(mapChunk, transform.position + new Vector3(0, -30, 0), Quaternion.identity); map_down.name = $"down{i}"; break;
                    case 2: GameObject map_left = Instantiate(mapChunk, transform.position + new Vector3(-30, 0, 0), Quaternion.identity); map_left.name = $"left{i}"; break;
                    case 3: GameObject map_right = Instantiate(mapChunk, transform.position + new Vector3(30, 0, 0), Quaternion.identity); map_right.name = $"right{i}"; break;
                    case 4: GameObject map_leftUp = Instantiate(mapChunk, transform.position + new Vector3(-30, 30, 0), Quaternion.identity); map_leftUp.name = $"leftUp{i}"; break;
                    case 5: GameObject map_rightUp = Instantiate(mapChunk, transform.position + new Vector3(30, 30, 0), Quaternion.identity); map_rightUp.name = $"rightUp{i}"; break;
                    case 6: GameObject map_leftDown = Instantiate(mapChunk, transform.position + new Vector3(-30, -30, 0), Quaternion.identity); map_leftDown.name = $"leftDown{i}"; break;
                    case 7: GameObject map_rightDown = Instantiate(mapChunk, transform.position + new Vector3(30, -30, 0), Quaternion.identity); map_rightDown.name = $"rightDown{i}"; break;
                }
            }
            
        }
    }
}
