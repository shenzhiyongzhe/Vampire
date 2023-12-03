using System.Collections;
using UnityEngine;
using CharacterData = Assets.Scripts.Character.CharacterData;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float distance;
    Transform player;
    void Start()
    {
        player = PlayerMove.GetInstance().transform;

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
        float rand = Random.value * 10;
        while (true)
        {
            SpawnFlyingEye();
            SpawnMushroom();
            yield return new WaitForSeconds(rand);
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
