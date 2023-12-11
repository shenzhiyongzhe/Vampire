using System.Collections;
using UnityEngine;


public class BibleSpawner : WeaponSpawner
{
    protected override IEnumerator StartAttack()
    {
        while (true)
        {
            for(int i = 0; i < WeaponNum; i++)
            {
                GameObject obj = SpawnWeapon();
                obj.transform.position = new Vector3(Mathf.Cos(2 * Mathf.PI / WeaponNum * i) * AttackRange,
                                                     Mathf.Sin(2 * Mathf.PI / WeaponNum * i) * AttackRange, 0) + Player.position;
            }
            yield return new WaitForSeconds(CoolDownTime + LastTime);      
        }
    }
}
