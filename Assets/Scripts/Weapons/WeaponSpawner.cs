
using System.Collections;
using UnityEngine;

public abstract class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;

    public  PlayerMove PlayerMoveIns { get; private set; }
    public EnemySpawner EnemySpawnerIns { get; private set; }
    public float AttackSpeed { get; set; }
    public int AttackPower { get; set; }
    public float LastTime { get; set; }
    public float CoolDownTime { get; set; }
    public float AttackRange { get; set; }
    public int WeaponNum { get; set;}
    public int WeaponLevel { get; set;}

    public bool isActive { get; set; } = false;
    private void Awake()
    {
        Initialize();
    }
    private void Start()
    {
        PlayerMoveIns = PlayerMove.Instance;
        EnemySpawnerIns = EnemySpawner.Instance;
    }
    void Initialize()
    {
        AttackSpeed = weaponData.AttackSpeed;
        AttackPower = weaponData.AttackPower;
        LastTime = weaponData.LastTime;
        CoolDownTime = weaponData.CoolDownTime;
        AttackRange = weaponData.AttackRange;
        WeaponNum = weaponData.WeaponNum;
        WeaponLevel = 1;
    }
    protected GameObject SpawnWeapon()
    {
        GameObject obj = ObjectPool.GetObject(weaponData.WeaponName);
        obj.GetComponent<Weapon>().SetParameters(weaponData, AttackPower, CoolDownTime, LastTime, AttackSpeed);
        return obj;
    }
    public WeaponData GetWeaponData()
    {
        return weaponData;
    }
    public WeaponData.WeaponType GetWeaponType()
    {
        return weaponData.WeaponName;
    }

    protected Coroutine weaponCoroutine;
    protected bool IsMaxLevel { get; set; } = false;
    public void StartWeapon()
    {
        weaponCoroutine =  StartCoroutine(StartAttack());
    }
    public void ReStartWeapon()
    {
        StopCoroutine(weaponCoroutine);
        StartWeapon();
    }
    protected abstract IEnumerator StartAttack();

    public abstract void UpgradeWeapon();
}