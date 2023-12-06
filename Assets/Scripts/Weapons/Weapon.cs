using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponData weaponData;
    float _attackSpeed;
    public int attackPower;
    protected float cooldownTime;
    float lastTime;
    public float AttackSpeed => _attackSpeed;

    void OnEnable()
    {
        StartCoroutine(StartDestroy());
    }
 
    public void SetParameters(WeaponData weaponData, int attackPower, float cooldownTime, float attackSpeed)
    {
        this.weaponData = weaponData;
        this.attackPower = attackPower;
        this.cooldownTime = cooldownTime;
        _attackSpeed = attackSpeed;
    }
    //IEnumerator 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().GetHurt(attackPower);
            Debug.Log(AttackSpeed);
        }
    }
    protected virtual IEnumerator StartDestroy()
    {
        yield return new WaitForSeconds(3);

        InactivateWeapon();
    }
    protected void InactivateWeapon()
    {
        ObjectPool.ReturnObject(WeaponData.WeaponType.Bible, this.gameObject);
        this.gameObject.SetActive(false);
    }

}