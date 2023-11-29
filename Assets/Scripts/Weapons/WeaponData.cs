using UnityEngine;


[CreateAssetMenu(fileName = "Weapon Data", menuName = "Scriptable Object/Weapon Data", order = int.MaxValue)]
public class WeaponData : ScriptableObject
{
    public enum WeaponName
    {
        Whip, Axe, Bible, Lightning, MagicWand, FireWand
    }

    public enum Parent
    {
        Self, Player
    }

    [SerializeField] WeaponName _weaponName;
    [SerializeField] Parent _parent;
    [SerializeField] int _attackPower;
    [SerializeField] float _attackSpeed;
    [SerializeField] float _attackRange;
    [SerializeField] float _cooldownTime;
    [SerializeField] float _lastTime;
    [SerializeField] Sprite _weaponSprite;
    [SerializeField] string _description;

    public WeaponName Name => _weaponName; 
    public Parent GetParent => _parent;
    public int AttackPower => _attackPower;
    public float AttackSpeed => _attackSpeed;
    public float AttackRange => _attackRange;
    public float CooldownTime => _cooldownTime;
    public float LastTime => _lastTime;
    public Sprite WeaponSprite => _weaponSprite;
    public string Description => _description;
}