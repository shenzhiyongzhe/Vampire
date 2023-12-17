using System.Collections;
using UnityEngine;


public class AxeSpawner : WeaponSpawner
{

    protected override IEnumerator StartAttack()
    {
        while (true)
        {
            for (int i = 0; i < WeaponNum; i++)
            {
                GameObject obj = SpawnWeapon();
                obj.transform.position =  PlayerMove.position;
                obj.transform.SetParent(ObjectPool.Instance.transform, false);
                obj.transform.localScale = AttackRange * Vector3.one;
                obj.SetActive(true);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-6000 * Mathf.Cos(Mathf.PI / WeaponNum * i + Mathf.PI / -4) * AttackSpeed, 
                    -6000 * Mathf.Sin(Mathf.PI / WeaponNum * i + Mathf.PI / -4) * AttackSpeed), ForceMode2D.Force);
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
            case 5: AttackRange *= -1.5f; break;
            case 6: 
            case 7: AttackSpeed *= -1.4f; break;
            case 8: 
            case 9: CoolDownTime *= -0.5f; break;
        }
        ReStartWeapon();
    }

}