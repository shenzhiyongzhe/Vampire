using System.Collections;
using UnityEngine;


public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] GameObject weaponPrefab;
    // Use this for initialization
    void Start()
    {
        ObjectPoolManager.SpawnObject(weaponPrefab, transform.position, Quaternion.identity);
    }

}