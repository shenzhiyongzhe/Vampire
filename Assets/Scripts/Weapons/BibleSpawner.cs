using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BibleSpawner : WeaponSpawner
{
    [SerializeField] WeaponData weaponData;
    WeaponData.WeaponName weaponName;
    [SerializeField] int weaponNumber;
    [SerializeField] float attackRange;
    [SerializeField] float lastTime;
    [SerializeField] float cooldownTime;


    // Use this for initialization
    void Start()
    {
        
        weaponName = weaponData.Name;
        //attackRange = weaponData.AttackRange;
        //lastTime = weaponData.LastTime;
        //cooldownTime = weaponData.CooldownTime;
        StartCoroutine(Attack(weaponName, weaponNumber, attackRange, lastTime, cooldownTime));
    }

   

}
