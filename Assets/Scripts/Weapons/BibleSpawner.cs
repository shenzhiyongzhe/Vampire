using System.Collections;
using UnityEngine;


public class BibleSpawner : WeaponSpawner
{
    protected override IEnumerator StartAttack()
    {
        while (true)
        {
            for(int i = 0; i < WeaponNum; i++)
            {
                GameObject obj = SpawnWeapon();
                obj.transform.position = new Vector3(Mathf.Cos(2 * Mathf.PI / WeaponNum * i) * AttackRange,
                                                     Mathf.Sin(2 * Mathf.PI / WeaponNum * i) * AttackRange, 0) + PlayerMove.position;
                obj.SetActive(true);
            }
            yield return new WaitForSeconds(CoolDownTime + LastTime);      
        }
    }

    public override void UpgradeWeapon()
    {
        if(!IsMaxLevel)
        {
            WeaponLevel++;

            if(WeaponLevel == 9)
                IsMaxLevel = true;

            switch (WeaponLevel)
            {
                default:
                    break;
                case 2: 
                case 3: WeaponNum++; break;
                case 4: 
                case 5: AttackSpeed *= 1.5f; break;
                case 6: 
                case 7: AttackRange *= 1.5f; break;
                case 8: 
                case 9: AttackPower += 10; break;
            }
            ReStartWeapon();
        }


    }
}
