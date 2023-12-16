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
                                                     Mathf.Sin(2 * Mathf.PI / WeaponNum * i) * AttackRange, 0) + PlayerMove.position;
            }
            yield return new WaitForSeconds(CoolDownTime + LastTime);      
        }
    }

    public override void UpgradeWeapon()
    {
        if(!IsMaxLevel)
        {
            WeaponLevel++;

            if(WeaponLevel == 9)
                IsMaxLevel = true;

            switch (WeaponLevel)
            {
                default:
                    break;
                case 1: WeaponNum++; break;
                case 2: WeaponNum++; break;
                case 3: WeaponNum++; break;
                case 4: WeaponNum++; break;
                case 5: WeaponNum++; break;
                case 6: WeaponNum++; break;
                case 7: WeaponNum++; break;
                case 8: WeaponNum++; break;
                case 9: WeaponNum++; break;
            }
            ReStartWeapon();
        }


    }
}
