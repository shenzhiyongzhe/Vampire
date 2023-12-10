using System.Collections;
using UnityEngine;


public class LightningSpawner : WeaponSpawner
{

    protected override IEnumerator StartAttack()
    {
        while (true)
        {
            for (int i = 0; i < weaponNum; i++)
            {
                GameObject obj = SpawnWeapon();
                obj.transform.SetParent(transform, false);
                obj.transform.position = new Vector3(Mathf.Cos(2 * Mathf.PI / weaponNum * i) * attackRange,
                                                     Mathf.Sin(2 * Mathf.PI / weaponNum * i) * attackRange, 0) + Player.position;
            }
            yield return new WaitForSeconds(cooldownTime + lastTime);
        }
    }
}
