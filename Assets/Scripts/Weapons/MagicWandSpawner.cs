using System.Collections;
using UnityEngine;


public class MagicWandSpawner : WeaponSpawner
{

    protected override IEnumerator StartAttack()
    {
        while (true)
        {
            for (int i = 0; i < WeaponNum; i++)
            {
                GameObject obj = SpawnWeapon();
                obj.transform.SetParent(transform, false);
                obj.transform.position = PlayerMove.position;
            }
            yield return new WaitForSeconds(CoolDownTime + LastTime);
        }
    }
    public override void UpgradeWeapon()
    {
        WeaponLevel++;
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
    }
}
