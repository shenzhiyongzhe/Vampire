using System.Collections;
using UnityEngine;


public class FireWandSpawner : WeaponSpawner
{

    protected override IEnumerator StartAttack()
    {
        while (true)
        {
            for (int i = 0; i < WeaponNum; i++)
            {
                GameObject obj = SpawnWeapon();
                obj.transform.SetParent(transform, false);
                obj.transform.position = Player.position;
            }
            yield return new WaitForSeconds(CoolDownTime + LastTime);
        }
    }
}
