using System.Collections;
using UnityEngine;


public class WhipSpawner : WeaponSpawner
{
    protected override IEnumerator StartAttack()
    {
        PlayerMove direction = global::PlayerMove.Instance;
        while (true)
        {
            for (int i = 0; i < WeaponNum; i++)
            {
                GameObject obj = SpawnWeapon();
                obj.transform.localScale = AttackRange * Vector3.one;
                obj.transform.position = PlayerMoveIns.transform.position;
                obj.transform.rotation = Quaternion.identity;
                obj.SetActive(true);

                switch (i)
                {
                    case 0: obj.GetComponent<Rigidbody2D>().AddForce(direction.IsFacingRight ? 1000 * AttackSpeed * Vector2.right : 1000 * AttackSpeed * Vector2.left, ForceMode2D.Force);
                        if(!direction.IsFacingRight) obj.GetComponent<SpriteRenderer>().flipX = true; break;
                    case 1: obj.GetComponent<Rigidbody2D>().AddForce(direction.IsFacingRight ? 1000 * AttackSpeed * Vector2.left: 1000 * AttackSpeed * Vector2.right, ForceMode2D.Force);
                         if(direction.IsFacingRight) obj.GetComponent<SpriteRenderer>().flipX = true;
                         else obj.GetComponent<SpriteRenderer>().flipX = false; break;
                    case 2: obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000 * AttackSpeed), ForceMode2D.Force);
                        obj.transform.rotation = Quaternion.Euler(0, 60, 90); break;
                    case 3: obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1000 * AttackSpeed), ForceMode2D.Force);
                        obj.transform.rotation = Quaternion.Euler(0, -60, -90); break;
                    default:
                        Debug.Log("whip");break;
                    
                }
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
            case 3: 
            case 4: WeaponNum++; break;
            case 5: 
            case 6: AttackSpeed *= 1.4f; break;
            case 7: 
            case 8: AttackRange *= 0.5f; break;
            case 9: AttackPower += 10; break;
        }
        ReStartWeapon();
    }
}
