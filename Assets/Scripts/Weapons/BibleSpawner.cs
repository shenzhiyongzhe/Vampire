using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BibleSpawner : MonoBehaviour
{
    [SerializeField] GameObject biblePrefab;
    [SerializeField] WeaponData weaponData;
    [SerializeField] int spawnNumber;
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
        //StartCoroutine(DeactiveBible());
    }

    private IEnumerator SpawnBible() 
    {
        while (true)
        {
            Queue<GameObject> spawnedQuene = new();
            for(int i = 0; i < spawnNumber; i++)
            {
                GameObject obj = ObjectPool.GetObject(WeaponData.WeaponName.Bible);
                obj.SetActive(true);      
                spawnedQuene.Enqueue(obj);
            }
            yield return new WaitForSeconds(inactiveDelay);
            foreach (GameObject obj in spawnedQuene)
            {
                obj.SetActive(false);   
                ObjectPool.ReturnObject(WeaponData.WeaponName.Bible, obj);
            }
        }
    }


}
