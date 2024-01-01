using UnityEngine;


[CreateAssetMenu(fileName = "Weapon Data", menuName = "Scriptable Object/Weapon Data", order = int.MaxValue)]
public class WeaponData : ScriptableObject
{
    public enum WeaponType
    {
         Axe, Bible, Lightning, MagicWand, FireWand, Whip, Sword, SnowFlower
    }

    [SerializeField] WeaponType weaponName;
    [SerializeField] int attackPower;
    [SerializeField] int weaponNum;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackRange;
    [SerializeField] float cooldownTime;
    [SerializeField] float lastTime;
    [SerializeField] Sprite weaponSprite;
    [SerializeField] string description;


    public WeaponType WeaponName => weaponName;
    public int AttackPower => attackPower;
    public int WeaponNum => weaponNum;
    public float AttackSpeed => attackSpeed;
    public float AttackRange => attackRange;
    public float CoolDownTime => cooldownTime;
    public float LastTime => lastTime;
    public Sprite WeaponSprite => weaponSprite;
    public string Description => description;


}