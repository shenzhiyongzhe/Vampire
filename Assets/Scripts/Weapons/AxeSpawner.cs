using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class AxeSpawner : MonoBehaviour
    {
        [SerializeField] GameObject axePrefab;
        // Use this for initialization
        void Start()
        {

        }
        
        void SpawnAxe()
        {
            GameObject obj = ObjectPool.GetObject(WeaponData.WeaponName.Axe);
            obj.SetActive(true);
        }
    }
}