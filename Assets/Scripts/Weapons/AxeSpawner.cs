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
            for(int i = 0; i < 10; i++)
            {
                SpawnAxe();
            }
        }
        
        void SpawnAxe()
        {
            GameObject obj = ObjectPool.GetObject(WeaponData.WeaponName.Axe, transform);
            obj.SetActive(true);
        }
    }
}