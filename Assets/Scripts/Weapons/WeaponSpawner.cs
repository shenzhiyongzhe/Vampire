using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static WeaponData;


public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    WeaponData.WeaponName weaponName;
    float attackRange;
    float lastTime;
    float cooldownTime;
    [SerializeField] int weaponNum;
    void Awake()
    {
        Initialize();
    }
    protected void Initialize()
    {
        weaponName = weaponData.Name;
        attackRange = weaponData.AttackRange;
        lastTime = weaponData.LastTime;
        cooldownTime = weaponData.CooldownTime;
        weaponNum = weaponData.WeaponNum;
    }

    protected void SpawnWeapon()
    {  
        for(int i = 0; i < weaponNum; i++)
        {  
            GameObject obj = ObjectPool.GetObject(weaponName, transform);
            obj.SetActive(true);
            obj.transform.position = new Vector3(Mathf.Cos(2 * Mathf.PI / weaponNum * i) * attackRange,
                Mathf.Sin(2 * Mathf.PI / weaponNum * i) * attackRange, 0) + transform.position;
            obj.GetComponent<Weapon>().SetParameters(weaponName, lastTime, cooldownTime);
        }
  
    }

}