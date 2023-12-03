using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BibleSpawner : WeaponSpawner
{
    [SerializeField] protected WeaponData weaponData;
    WeaponData.WeaponType weaponBible;
    //float attackRange;
    //float lastTime;
    //float cooldownTime;
    //[SerializeField] int weaponNum;
    // Use this for initialization
    void Start()
    {
        weaponBible = WeaponData.WeaponType.Bible;
        StartCoroutine(SpawnBible());
    }
    IEnumerator SpawnBible()
    {
        while (true)
        {
            for(int i = 0; i < weaponData.WeaponNum; i++)
            {
                GameObject obj = ObjectPool.GetObject(weaponBible);

                obj.transform.SetParent(this.transform);
                obj.transform.position = new Vector3(Mathf.Cos(2 * Mathf.PI / weaponData.WeaponNum * i) * weaponData.AttackRange,
                    Mathf.Sin(2 * Mathf.PI / weaponData.WeaponNum * i) * weaponData.AttackRange, 0) + transform.position;
                obj.SetActive(true);
                StartCoroutine(SetInactive(obj, weaponData.LastTime, weaponData.Name));
            }

            yield return new WaitForSeconds(weaponData.CooldownTime + weaponData.LastTime);

        }
    }


}
