using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BibleSpawner : MonoBehaviour
{
    [SerializeField] GameObject biblePrefab;
    [SerializeField] WeaponData weaponData;
    [SerializeField] int spawnNumber;
    [SerializeField] float radius;
    int attackPower;
    float attackSpeed;
    float inactiveDelay;

    // Use this for initialization
    void Start()
    {
        attackPower = weaponData.AttackPower;
        attackSpeed = weaponData.AttackSpeed;   
        inactiveDelay = weaponData.InactiveDelay;
        StartCoroutine(SpawnBible());
        //StartCoroutine(OrderFor());
        //StartCoroutine(DeactiveBible());
    }

    private IEnumerator SpawnBible() 
    {
        while (true)
        {
            Queue<GameObject> spawnedQuene = new();
            for(int i = 0; i < spawnNumber; i++)
            {
                GameObject obj = ObjectPool.GetObject(WeaponData.WeaponName.Bible, transform);
                obj.SetActive(true);
                obj.transform.position = new Vector3(Mathf.Cos(2*Mathf.PI / spawnNumber * i) * radius, Mathf.Sin(2 * Mathf.PI / spawnNumber * i)* radius, 0) + transform.position;
                obj.transform.SetParent(transform, false);
                spawnedQuene.Enqueue(obj);
            }
            yield return new WaitForSeconds(inactiveDelay);
            foreach (GameObject obj in spawnedQuene)
            {
                obj.SetActive(false);
                obj.transform.position = Vector3.zero;
                ObjectPool.ReturnObject(WeaponData.WeaponName.Bible, obj);
                Debug.Log("enqueue");
            }
        }
    }

    IEnumerator OrderFor()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Debug.Log($"i = {i}");
        }
        Debug.Log("------");
        yield return new WaitForSeconds(1);
        for(int j = 0; j < 10; j++)
        {
            Debug.Log($"j = {j}");

        }
    }
}
