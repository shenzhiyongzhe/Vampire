using System.Collections;
using UnityEngine;


public class AxeSpawner : WeaponSpawner
{
    [SerializeField] WeaponData weaponData;
    WeaponData.WeaponName weaponName;
    [SerializeField] int weaponNumber;
    [SerializeField] float attackRange;
    [SerializeField] float lastTime;
    [SerializeField] float cooldownTime;

    private void Start()
    {
        weaponName = weaponData.Name;
        StartCoroutine(Attack(weaponName, weaponNumber, attackRange, lastTime, cooldownTime));
        
    }

}