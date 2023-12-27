using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponData weaponData;

    protected float AttackSpeed { get; private set; }
    public int AttackPower { get; private set; }
    protected float CoolDownTime { get; private set; }
    protected float LastTime { get; private set; }

    public  PlayerMove PlayerMoveIns {get; private set; }
    public EnemySpawner EnemySpawnerIns { get; private set; }

    void OnEnable()
    {
        StartCoroutine(StartDestroy());
    }

    private void Start()
    {
        PlayerMoveIns = PlayerMove.Instance;
        EnemySpawnerIns = EnemySpawner.Instance;
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