using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagicWandSpawner : WeaponSpawner
{
    protected override IEnumerator StartAttack()
    {
        while (true)
        {
            for (int i = 0; i < WeaponNum; i++)
            {
                if (EnemySpawnerIns.activeEnemyList.Count == 0) break;
                GameObject obj = SpawnWeapon();
                obj.transform.position = PlayerMoveIns.transform.position;
                obj.SetActive(true);
                obj.GetComponent<Rigidbody2D>().AddForce(100 * (EnemySpawnerIns.GetNearestPos().transform.position - PlayerMoveIns.transform.position), ForceMode2D.Force);
            }

            yield return new WaitForSeconds(CoolDownTime);
        }
    }


    public override void UpgradeWeapon()
    {
        WeaponLevel++;
        switch (WeaponLevel)
        {
            default:
                break;
            case 2: 
            case 3: WeaponNum++; break;
            case 4: WeaponNum++; break;
            case 5: WeaponNum++; break;
            case 6: WeaponNum++; break;
            case 7: WeaponNum++; break;
            case 8: WeaponNum++; break;
            case 9: WeaponNum++; break;
        }
    }
}
