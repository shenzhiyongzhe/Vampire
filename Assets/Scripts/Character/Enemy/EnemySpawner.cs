using System.Collections;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float distance;
    Transform player;
    void Start()
    {
        player = PlayerMove.Instance.transform;

        StartCoroutine(LoopSpawnEnemy());
    }
    void SpawnEnemy(CharacterData.CharacterType enemyType)
    {
        GameObject obj = ObjectPool.GetObject(enemyType);
        float rand = Random.value;
        Vector3 atCircle = new Vector3(Mathf.Cos(2 * Mathf.PI * rand), Mathf.Sin(2 * Mathf.PI * rand), 0) * distance;
        obj.transform.position = atCircle + player.position;
        obj.SetActive(true);
        //return obj;
    }

    IEnumerator LoopSpawnEnemy()
    {
        while (true)
        {
            //float rand = Random.value * 3;
            //SpawnFlyingEye();
            SpawnMushroom();
            yield return new WaitForSeconds(1f);
        }
    }
    void SpawnFlyingEye()
    {
        SpawnEnemy(CharacterData.CharacterType.FlyingEye);
    }

    void SpawnMushroom()
    {
        SpawnEnemy(CharacterData.CharacterType.Mushroom);
    }
}
