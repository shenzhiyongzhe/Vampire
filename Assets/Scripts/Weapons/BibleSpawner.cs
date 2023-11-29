using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BibleSpawner : WeaponSpawner
{
    [SerializeField] WeaponData weaponData;
    WeaponData.WeaponName weaponName;
    [SerializeField] int weaponNumber;
    float attackRange;
    float lastTime;
    float cooldownTime;


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        //weaponName = weaponData.Name;
        //attackRange = weaponData.AttackRange;
        //lastTime = weaponData.LastTime;
        //cooldownTime = weaponData.CooldownTime;
        StartCoroutine(Attack(weaponNumber, attackRange, lastTime, cooldownTime));
    }

   

}
