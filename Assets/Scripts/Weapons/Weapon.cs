using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponData weaponData;

    protected float attackSpeed;
    public int attackPower;
    protected float cooldownTime;
    float lastTime;

    private Transform player;
    public Transform Player => player;
    void OnEnable()
    {
        StartCoroutine(StartDestroy());
    }

    private void Start()
    {
        player = PlayerMove.Instance.transform;
    }
    public void SetParameters(WeaponData weaponData, int attackPower, float cooldownTime, float lastTime, float attackSpeed)
    {
        this.weaponData = weaponData;
        this.attackPower = attackPower;
        this.cooldownTime = cooldownTime;
        this.lastTime = lastTime;
        this.attackSpeed = attackSpeed;
    }
    //IEnumerator 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().GetHurt(attackPower);
        }
    }
    protected virtual IEnumerator StartDestroy()
    {
        yield return new WaitForSeconds(lastTime);

        InactivateWeapon();
    }
    protected void InactivateWeapon()
    {
        gameObject.SetActive(false);
        ObjectPool.ReturnObject(weaponData.WeaponName, gameObject);
    }

}