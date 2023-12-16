using System.Collections;
using UnityEngine;


public class WhipSpawner : WeaponSpawner
{

    protected override IEnumerator StartAttack()
    {
        while (true)
        {
            for (int i = 0; i < WeaponNum; i++)
            {
                GameObject obj = SpawnWeapon();
                obj.transform.SetParent(transform, false);
                switch (i)
                {
                    case 0: obj.transform.position = PlayerMove.position + 2* Vector3.right;break;
                    case 1: obj.transform.position = PlayerMove.position - 2* Vector3.right;
                        obj.GetComponent<SpriteRenderer>().flipX = true; break;
                    case 3: obj.transform.position = PlayerMove.position + new Vector3(2, 4, 0); break;
                    default:
                        Debug.Log("whip");break;
                    
                }
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
