
using System.Collections;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    protected Transform playerPos;

    protected float attackSpeed;
    protected int attackPower;
    protected float lastTime;
    protected float cooldownTime;
    protected float attackRange;
    protected int weaponNum;

    private void Awake()
    {
        Initialize();
        playerPos = PlayerMove.GetInstance().transform;
    }

    void Initialize()
    {
        attackSpeed = weaponData.AttackSpeed;
        attackPower = weaponData.AttackPower;
        lastTime = weaponData.LastTime;
        cooldownTime = weaponData.CooldownTime;
        attackRange = weaponData.AttackRange;
        weaponNum = weaponData.WeaponNum;
    }
    protected GameObject SpawnWeapon()
    {
        GameObject obj = ObjectPool.GetObject(weaponData.Name);
        obj.SetActive(true);
        obj.GetComponent<Weapon>().SetParameters(weaponData, attackPower, cooldownTime, attackSpeed);
        return obj;
    }

}