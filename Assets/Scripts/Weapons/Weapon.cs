using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    float _attackSpeed;
    int _attackPower;
    public float AttackSpeed => _attackSpeed;
    public int AttackPower => _attackPower;

    private void Awake()
    {
        _attackSpeed = weaponData.AttackSpeed;
    }
    //IEnumerator 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().GetHurt(_attackPower);
            }
    }
}