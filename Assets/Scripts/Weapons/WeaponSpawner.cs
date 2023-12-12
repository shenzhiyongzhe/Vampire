
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

    public void UpgradeWeapon()
    {
        WeaponLevel++;
        switch (WeaponLevel)
        {
            case 2: WeaponNum++; break;
            case 3: WeaponNum++; break;
            case 4: AttackSpeed *= 1+0.2f; break;
            case 5: AttackSpeed *= 1+0.3f; break;
            case 6: AttackRange *= 1 + 0.3f; break;
            case 7: WeaponNum++; break;
            case 8: WeaponNum++; break;
            case 9: WeaponNum++; break;
        }
        Debug.Log(weaponData.WeaponName.ToString() + ": " + WeaponLevel.ToString());
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
        WeaponLevel = 1;
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