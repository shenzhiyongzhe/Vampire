using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    LevelUp player;
    TMP_Dropdown weaponDropdown;
    TMP_Dropdown accessoryDropdown;
    public void AddEnemy()
    {
        EnemySpawner.Instance.SpawnEnemy(CharacterData.CharacterType.FlyingEye);
    }

    public void WeaponUpgrade()
    {
        weaponDropdown = GetComponent<TMP_Dropdown>();
        string value = weaponDropdown.options[weaponDropdown.value].text;
        switch (value)
        {
            default:
                break;
            case "Bible": Inventory.Instance.AddWeapon(WeaponData.WeaponType.Bible); break;
            case "Axe": Inventory.Instance.AddWeapon(WeaponData.WeaponType.Axe); break;
            case "Whip": Inventory.Instance.AddWeapon(WeaponData.WeaponType.Whip); break;
            case "Lightning": Inventory.Instance.AddWeapon(WeaponData.WeaponType.Lightning); break;
            case "MagicWand": Inventory.Instance.AddWeapon(WeaponData.WeaponType.MagicWand); break;
            case "FireWand": Inventory.Instance.AddWeapon(WeaponData.WeaponType.FireWand); break;
        }
    }

    public void AccessoryUpgrade()
    {
        accessoryDropdown = GetComponent<TMP_Dropdown>();
        string value = accessoryDropdown.options[accessoryDropdown.value].text;
        switch (value)
        {
            default:
                break;
            case "Armor": Inventory.Instance.AddAccessory(AccessoryData.AccessoryType.Armor); break;
            case "Clover": Inventory.Instance.AddAccessory(AccessoryData.AccessoryType.Clover); break;
            case "Crown": Inventory.Instance.AddAccessory(AccessoryData.AccessoryType.Crown); break;
            case "EmptyTome": Inventory.Instance.AddAccessory(AccessoryData.AccessoryType.EmptyTome); break;
            case "Spinach": Inventory.Instance.AddAccessory(AccessoryData.AccessoryType.Spinach); break;
            case "Wings": Inventory.Instance.AddAccessory(AccessoryData.AccessoryType.Wings); break;
        }
    }
    public void PlayerLvUp()
    {
        player = GameObject.FindWithTag("Player").GetComponent<LevelUp>();
        player.OnLevelUp();
    }
}
