using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlowerSpawner : WeaponSpawner
{
    public override void UpgradeWeapon()
    {
        WeaponLevel++;

        switch (WeaponLevel)
        {
            default:
                break;
            case 2: WeaponNum++; break;
            case 3: WeaponNum++; break;
            case 4: WeaponNum++; break;
            case 5: WeaponNum++; break;
            case 6: WeaponNum++; break;
            case 7: WeaponNum++; break;
            case 8: WeaponNum++; break;
            case 9: WeaponNum++; break;
        }
    }

    protected override IEnumerator StartAttack()
    {
        while (true)
        {
            for(int i =  0; i < WeaponNum; i++)
            {
                GameObject obj = SpawnWeapon();
                obj.transform.position = PlayerMoveIns.transform.position;  
                obj.SetActive(true);
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(CoolDownTime);
            
        }
    }
}
