using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponSpawner : MonoBehaviour
{
    WeaponData weaponData;
    WeaponData.WeaponName weaponName;
    float attackRange;
    float lastTime;
    float cooldownTime;
    protected virtual void Start()
    {
        weaponName = weaponData.Name;
        attackRange = weaponData.AttackRange;
        lastTime = weaponData.LastTime;
        cooldownTime = weaponData.CooldownTime;
    }

    protected IEnumerator Attack(int weaponNumber, float attackRange, float lastTime, float cooldownTime)
    {
        while (true)
        {
            Queue<GameObject> spawnedQuene = new();
            for (int i = 0; i < weaponNumber; i++)
            {
                GameObject obj = ObjectPool.GetObject(weaponName, transform);
                obj.SetActive(true);
                obj.transform.position = new Vector3(Mathf.Cos(2 * Mathf.PI / weaponNumber * i) * attackRange, 
                    Mathf.Sin(2 * Mathf.PI / weaponNumber * i) * attackRange, 0) + transform.position;
                spawnedQuene.Enqueue(obj);
            }
            yield return new WaitForSeconds(lastTime);
            foreach (GameObject obj in spawnedQuene)
            {
                obj.SetActive(false);
                obj.transform.position = Vector3.zero;
                ObjectPool.ReturnObject(weaponName, obj);

            }
            yield return new WaitForSeconds(cooldownTime);
        }
    }

}