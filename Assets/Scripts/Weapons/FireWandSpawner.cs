using System.Collections;
using UnityEngine;


public class FireWandSpawner : WeaponSpawner
{
    const float spreadAngle = 15f;
    protected override IEnumerator StartAttack()
    {
        EnemySpawner enemySpawner = EnemySpawner.Instance;
        while (true)
        {

            if (enemySpawner.activeEnemyList.Count > 0)
            {
                Vector2 destination = enemySpawner.GetRandomPos().transform.position;
                float newSpreadAngle = 0f;

                for (int i = 0; i < WeaponNum; ++i)
                {
                    if (i % 2 == 1)
                        newSpreadAngle += spreadAngle;

                    SpawnWeapon(destination);

                    newSpreadAngle *= -1;
                }
            }
            yield return new WaitForSeconds(CoolDownTime + 2f);
        }

       
    }
    public void SpawnWeapon(Vector2 destination)
    {
        GameObject obj = ObjectPool.GetObject(GetWeaponType());
        obj.transform.position = PlayerMoveIns.transform.position;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(destination.y - obj.transform.position.y, destination.x - obj.transform.position.x);

        obj.transform.rotation = Quaternion.Euler(0, 0, angle);
        obj.GetComponent<Weapon>().SetParameters(GetWeaponData(), AttackPower, CoolDownTime, LastTime, AttackSpeed);
        obj.SetActive(true);
        obj.GetComponent<Rigidbody2D>().AddForce(200f * AttackSpeed * (destination - (Vector2)PlayerMoveIns.transform.position).normalized, ForceMode2D.Force);

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
