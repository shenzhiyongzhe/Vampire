using System.Collections;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    [SerializeField] WeaponData whip;
    [SerializeField] WeaponData axe;
    [SerializeField] WeaponData bible;
    [SerializeField] WeaponData magicWand;
    [SerializeField] WeaponData lightning;
    [SerializeField] WeaponData fireWand;
    [SerializeField] WeaponData sword;
    [SerializeField] WeaponData snowFlower;

    [SerializeField] AccessoryData armor;
    [SerializeField] AccessoryData clover;
    [SerializeField] AccessoryData crown;
    [SerializeField] AccessoryData emptyTome;
    [SerializeField] AccessoryData spinach;
    [SerializeField] AccessoryData wings;

    static ItemAssets instance;

    void Awake()
    {
        instance = this;
    }

    public static ItemAssets Instance => instance;

    public WeaponData GetWeaponData(WeaponData.WeaponType weaponType)
    {
        return weaponType switch
        {
            WeaponData.WeaponType.Bible => bible,
            WeaponData.WeaponType.Lightning => lightning,
            WeaponData.WeaponType.MagicWand => magicWand,
            WeaponData.WeaponType.FireWand => fireWand,
            WeaponData.WeaponType.Whip => whip,
            WeaponData.WeaponType.Sword => sword,
            WeaponData.WeaponType.SnowFlower => snowFlower,
            _ => axe,
        };
    }
    public AccessoryData GetAccessoryData(AccessoryData.AccessoryType type)
    {
        return type switch
        {
            AccessoryData.AccessoryType.Clover => clover,
            AccessoryData.AccessoryType.Crown => crown,
            AccessoryData.AccessoryType.EmptyTome => emptyTome,
            AccessoryData.AccessoryType.Spinach => spinach,
            AccessoryData.AccessoryType.Wings => wings,
            _ => armor,
        };
    }
}
