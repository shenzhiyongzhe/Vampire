using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        WeaponData weaponData;
        WeaponData.WeaponName weaponName;
        float attackRange;
        float lastTime;
        float cooldownTime;

        void OnEnable()
        {
            StartCoroutine(SetInactive());
        }

        public void SetParameters(WeaponData.WeaponName weaponName, float lastTime, float cooldownTime)
        {
            this.weaponName = weaponName;
            this.lastTime = lastTime;
            this.cooldownTime = cooldownTime;
            
        }

        IEnumerator SetInactive()
        {
            yield return new WaitForSeconds(cooldownTime);
            ObjectPool.ReturnObject(weaponName, gameObject);

        }
    }
}