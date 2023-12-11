
using System.Collections;
using UnityEngine;

public abstract class WeaponSpawner : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    Transform player;

    public Transform Player => player;



    public float AttackSpeed { get; set; }
    public int AttackPower { get; set; }
    public float LastTime { get; set; }
    public float CoolDownTime { get; set; }
    public float AttackRange { get; set; }

    public int WeaponNum {get; set;}

    public int WeaponLevel { get; set;}


    public void IncreaseLevel()
    {
        WeaponLevel++;
  
    }
    private void Awake()
    {
        Initialize();
    }
    private void Start()
    {
        player = PlayerMove.Instance.transform;
    }
    void Initialize()
    {
        AttackSpeed = weaponData.AttackSpeed;
        AttackPower = weaponData.AttackPower;
        LastTime = weaponData.LastTime;
        CoolDownTime = weaponData.CooldownTime;
        AttackRange = weaponData.AttackRange;
        WeaponNum = weaponData.WeaponNum;
    }
    protected GameObject SpawnWeapon()
    {
        GameObject obj = ObjectPool.GetObject(weaponData.WeaponName);
        obj.SetActive(true);
        obj.GetComponent<Weapon>().SetParameters(weaponData, AttackPower, CoolDownTime, AttackSpeed);
        return obj;
    }

    public WeaponData.WeaponType GetWeaponType()
    {
        return weaponData.WeaponName;
    }

  
    public void StartWeapon()
    {
        StartCoroutine(StartAttack());
    }
    protected abstract IEnumerator StartAttack();


}