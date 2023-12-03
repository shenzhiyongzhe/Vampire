
using System.Collections;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    int level;
    int attackPower;
    float attackSpeed;
    int finalAttackPower;
    float finalAttackSpeed;
    float cooldownTime;
    float additionalScale;
    Sprite weaponIcon;


    public WeaponData.WeaponType WeaponName => weaponData.Name; 
    void Awake()
    {
        Initialize();
    }


    protected void Initialize()
    {
        weaponIcon = weaponData.WeaponSprite;
        attackPower = weaponData.AttackPower;
        attackSpeed = weaponData.AttackSpeed;
        cooldownTime = weaponData.CooldownTime;
        level = 1;
        additionalScale = 100f;
    }

    public void SpawnWeapon()
    {
        GameObject weapon = ObjectPool.GetObject(WeaponName);
        weapon.GetComponent<Weapon>().SetParameters(weaponData, attackPower, cooldownTime);
        weapon.SetActive(true);
    }
}