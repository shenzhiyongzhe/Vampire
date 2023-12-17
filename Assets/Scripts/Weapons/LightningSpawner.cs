using System.Collections;
using UnityEngine;


public class LightningSpawner : WeaponSpawner
{

    protected override IEnumerator StartAttack()
    {
        EnemySpawner enemySpawner = EnemySpawner.Instance;
        while (true)
        {
            for (int i = 0; i < WeaponNum; i++)
            {
                if(enemySpawner.activeEnemyList.Count == 0) { break; }
                GameObject obj = SpawnWeapon();
                obj.transform.position = enemySpawner.GetRandomPos();
                obj.transform.localScale = AttackRange * Vector3.one;
                obj.SetActive(true);
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
            case 4: 
            case 5: AttackRange *= 1.4f; break;
            case 6: AttackRange *= 1.4f; break;
            case 7: WeaponNum++; break;
            case 8: WeaponNum++; break;
            case 9: WeaponNum++; break;
        }
        ReStartWeapon();
    }
}
