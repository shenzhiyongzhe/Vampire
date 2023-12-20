using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float distance;
    Transform player;

    [SerializeField] public List<GameObject> activeEnemyList = new();
    public static EnemySpawner Instance { get; private set; }


    float gameTime;
    void Awake()
    {
        Instance = this;
        player = PlayerMove.Instance.transform;
        gameTime = Mathf.FloorToInt(GameTime.GameDuration / 60f);

        //StartCoroutine(LoopSpawnEnemy());
        StartCoroutine(ListChecker());
    }
    public void SpawnEnemy(CharacterData.CharacterType enemyType)
    {
        GameObject obj = ObjectPool.GetObject(enemyType);
        float rand = Random.value;
        Vector3 atCircle = new Vector3(Mathf.Cos(2 * Mathf.PI * rand), Mathf.Sin(2 * Mathf.PI * rand), 0) * distance;
        obj.transform.position = atCircle + player.position;
        obj.SetActive(true);
        activeEnemyList.Add(obj);
    }

    IEnumerator LoopSpawnEnemy()
    {
        while (true)
        {
            switch (GetEnemyStage())
            {
                default: 
                case 1: SpawnEnemy(CharacterData.CharacterType.FlyingEye); break;
                case 2: SpawnEnemy(CharacterData.CharacterType.Mushroom); break; 
                case 3: SpawnEnemy(CharacterData.CharacterType.Mushroom); break;
                case 4: SpawnEnemy(CharacterData.CharacterType.Mushroom); break;
            }
            //float rand = Random.value * 3;

            yield return new WaitForSeconds(3f);
        }
    }


    int GetEnemyStage()
    {
        if (gameTime < 1f)
            return 1;
        else if (gameTime > 1f && gameTime < 2f)
            return 2;
        else if (gameTime > 2f && gameTime < 3f)
            return 3;
        else
            return 4;
    }

    public Vector3 GetRandomPos()
    {
        if (activeEnemyList.Count == 0) return Vector3.zero;
        return activeEnemyList[(int)Mathf.Floor(Random.Range(0, activeEnemyList.Count))].transform.position;
    }
    public GameObject GetNearestPos()
    {
        if (activeEnemyList.Count == 0) return null;
        float[] min = { 0, int.MaxValue };
        for(int i = 0; i < activeEnemyList.Count; i++)
        {
            if (min[1] > (activeEnemyList[i].transform.position - player.position).sqrMagnitude)
            {
                min[0] = i;
                min[1] = (activeEnemyList[i].transform.position - player.position).sqrMagnitude;
            }
        }
        return activeEnemyList[(int)min[0]];
    }

    IEnumerator ListChecker()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            activeEnemyList.RemoveAll(obj => obj.activeSelf == false);
        }
    }
}
