
using System.Collections;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    //[SerializeField] protected WeaponData weaponData;
    //WeaponData.WeaponName weaponName;
    //float attackRange;
    //float lastTime;
    //float cooldownTime;
    //int weaponNum;
    //void Awake()
    //{
    //    Initialize(weaponData);
    //}

    //void Initialize(WeaponData weaponData)
    //{
    //    this.weaponData = weaponData;
    //}
    //protected void SetParameters(WeaponData weaponData)
    //{
    //    weaponName = weaponData.Name;
    //    attackRange = weaponData.AttackRange;
    //    lastTime = weaponData.LastTime;
    //    cooldownTime = weaponData.CooldownTime;
    //    weaponNum = weaponData.WeaponNum;
    //}

    protected GameObject SpawnWeapon(WeaponData weaponData)
    {  

        GameObject obj = ObjectPool.GetObject(weaponData.Name);
        return obj;
        //obj.transform.SetParent(this.transform);
        //obj.SetActive(true);
        //obj.transform.position = new Vector3(Mathf.Cos(2 * Mathf.PI / weaponData.WeaponNum * i) * weaponData.AttackRange,
        //    Mathf.Sin(2 * Mathf.PI / weaponData.WeaponNum * i) * weaponData.AttackRange, 0) + transform.position;
        //StartCoroutine(SetInactive(obj, weaponData.LastTime, weaponData.Name));
            //obj.GetComponent<Weapon>().SetParameters(weaponData.Name, weaponData.LastTime, weaponData.CooldownTime);
        
  
    }

    protected IEnumerator SetInactive(GameObject obj, float lastTime, WeaponData.WeaponType weaponName)
    {
        yield return new WaitForSeconds(lastTime);
        ObjectPool.ReturnObject(weaponName, obj);
        obj.SetActive(false);
    }

}