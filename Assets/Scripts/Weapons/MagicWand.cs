using System.Collections;
using UnityEngine;

public class MagicWand : Weapon
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            InactivateWeapon();
        }
    }

}