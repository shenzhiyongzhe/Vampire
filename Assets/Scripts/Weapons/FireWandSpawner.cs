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
                Vector2 destination = (enemySpawner.GetNearestPos() - transform.position).normalized;
                float newSpreadAngle = 0f;

                for (int i = 0; i < WeaponNum; ++i)
                {
                    if (i % 2 == 1)
                        newSpreadAngle += spreadAngle;

                    SpawnWeapon(newSpreadAngle, destination);

                    newSpreadAngle *= -1;
                }
            }
            yield return new WaitForSeconds(CoolDownTime + 2f);
        }

       
    }
    public void SpawnWeapon(float spreadAngle, Vector2 destination)
    {
        GameObject obj = ObjectPool.GetObject(GetWeaponType());
        obj.transform.position = PlayerMove.position;
        Vector2 destVector;
        float angle;

        if (spreadAngle != 0f)
        {
            destination.x = destination.x * Mathf.Cos(spreadAngle / 180f * Mathf.PI) - destination.y * Mathf.Sin(spreadAngle / 180f * Mathf.PI);
            destination.y = destination.x * Mathf.Sin(spreadAngle / 180f * Mathf.PI) + destination.y * Mathf.Cos(spreadAngle / 180f * Mathf.PI);
        }
        destVector = destination.normalized;

        if (destVector.y < 0)
            angle = -Vector2.Angle(destVector, new Vector2(1, 0));
        else
            angle = Vector2.Angle(destVector, new Vector2(1, 0));

        obj.transform.rotation = Quaternion.Euler(0, 0, angle - 8.5f);
        obj.GetComponent<Weapon>().SetParameters(GetWeaponData(), AttackPower, CoolDownTime, LastTime, AttackSpeed);
        obj.SetActive(true);
        obj.GetComponent<Rigidbody2D>().AddForce(3000f * FlightSpeed * (destination - (Vector2)PlayerMove.position).normalized, ForceMode2D.Force);

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
