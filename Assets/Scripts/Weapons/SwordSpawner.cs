using System.Collections;
using UnityEngine;

public class SwordSpawner : WeaponSpawner
{
    public override void UpgradeWeapon()
    {
        Debug.Log("weaponNum++");
    }

    protected override IEnumerator StartAttack()
    {
        while (true)
        {
            for(int i = 0; i < WeaponNum; i++)
            {
                GameObject objRight = SpawnWeapon();
                objRight.transform.position = PlayerMoveIns.transform.position + new Vector3(2 + 2 * i, 5, 0);
                objRight.SetActive(true);
                GameObject objLeft = SpawnWeapon();
                objLeft.transform.position = PlayerMoveIns.transform.position + new Vector3(-2 - 2 * i, 5, 0);
                objLeft.SetActive(true);
            }
            yield return new WaitForSeconds(CoolDownTime);
        }

    }

    

}
