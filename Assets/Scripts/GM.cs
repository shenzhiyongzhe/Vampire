using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    LevelUp player;
    public void AddEnemy()
    {
        EnemySpawner.Instance.SpawnEnemy(CharacterData.CharacterType.FlyingEye);
    }

    public void WeaponUpgrade()
    {
        Inventory.Instance.AddWeapon(WeaponData.WeaponType.Bible);
    }

    public void PlayerLvUp()
    {
        player = GameObject.FindWithTag("Player").GetComponent<LevelUp>();
        player.OnLevelUp();
    }
}
