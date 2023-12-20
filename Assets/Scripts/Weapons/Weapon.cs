using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponData weaponData;

    protected float AttackSpeed { get; private set; }
    public int AttackPower { get; private set; }
    protected float CoolDownTime { get; private set; }
    protected float LastTime { get; private set; }

    private Transform player;
    public Transform PlayerMove => player;
    void OnEnable()
    {
        StartCoroutine(StartDestroy());
    }

    private void Start()
    {
        player = global::PlayerMove.Instance.transform;
    }
    public void SetParameters(WeaponData weaponData, int attackPower, float cooldownTime, float lastTime, float attackSpeed)
    {
        this.weaponData = weaponData;
        AttackPower = attackPower;
        CoolDownTime = cooldownTime;
        LastTime = lastTime;
        AttackSpeed = attackSpeed;
    }   
    //IEnumerator 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().GetHurt((int)Mathf.Ceil(AttackPower * Player.Instance.DamageBuff));
        }
    }
    protected virtual IEnumerator StartDestroy()
    {
        yield return new WaitForSeconds(LastTime);

        InactivateWeapon();
    }
    protected void InactivateWeapon()
    {
        gameObject.SetActive(false);
        ObjectPool.ReturnObject(weaponData.WeaponName, gameObject);
    }

}