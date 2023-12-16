using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] Transform weaponSlotTemplate;
    [SerializeField] Transform weaponSlotParent;
    [SerializeField] Transform accessoryTemplate;
    [SerializeField] Transform accessoryParent;

    RectTransform[] weaponSlots = new RectTransform[slotNum];
    RectTransform[] accessorySlots = new RectTransform[slotNum];

    static Dictionary<WeaponData.WeaponType, int> weaponInventory;
    static Dictionary<AccessoryData.AccessoryType, int> accessoryInventory;

    public static Dictionary<WeaponData.WeaponType, int> WeaponInventory => weaponInventory;
    public static Dictionary<AccessoryData.AccessoryType, int> AccessoryInventory => accessoryInventory;

    WeaponSpawner bible;

    const int slotNum = 6;
    const float slotSize = 48f;
    private static Inventory _instance;
    public static Inventory Instance => _instance;
    private void Awake()
    {
        weaponInventory = new();
        accessoryInventory = new();
        _instance = this;
        SlotInitialise();

        bible = GetComponent<BibleSpawner>();
        weaponInventory.Add(WeaponData.WeaponType.Bible, 1);
        bible.StartWeapon();

        ShowInventory();
    }

    private void SlotInitialise()
    {
        for (int i = 0; i < slotNum; i++)
        {
            weaponSlots[i] = Instantiate(weaponSlotTemplate, weaponSlotParent).GetComponent<RectTransform>();
            weaponSlots[i].anchoredPosition = new Vector2(i * slotSize, 0f);
            weaponSlots[i].gameObject.SetActive(true);
            accessorySlots[i] = Instantiate(accessoryTemplate, accessoryParent) as RectTransform;
            accessorySlots[i].anchoredPosition = new Vector2(i * slotSize, 0f);
            accessorySlots[i].gameObject.SetActive(true);
        }
    }

    public void AddWeapon(WeaponData.WeaponType weaponType)
    {
        WeaponSpawner spawner;

        switch (weaponType)
        {
            case WeaponData.WeaponType.Axe:
                spawner = GetComponent<AxeSpawner>();
                break;
            case WeaponData.WeaponType.Bible:
                spawner = bible;
                break;
            case WeaponData.WeaponType.Lightning:
                spawner = GetComponent<LightningSpawner>();
                break;
            case WeaponData.WeaponType.MagicWand:
                spawner = GetComponent<MagicWandSpawner>();
                break;
            case WeaponData.WeaponType.FireWand:
                spawner = GetComponent<FireWandSpawner>();
                break;
            case WeaponData.WeaponType.Whip:
                spawner = GetComponent<WhipSpawner>();
                break;
            default:
                Debug.Log("not found this weapon");
                spawner = bible;
                break;
        }

        WeaponData.WeaponType type = spawner.GetWeaponType();   
        if (weaponInventory.ContainsKey(weaponType))
        {
            spawner.UpgradeWeapon();
            weaponInventory[weaponType] = spawner.WeaponLevel;
            Debug.Log($" {weaponType}: {spawner.WeaponLevel}, {weaponInventory[weaponType]}");
        }
        else
        {
            weaponInventory.Add(type, 1);
            spawner.StartWeapon();
        }

        ShowInventory();
    }

    public void AddAccessory(AccessoryData.AccessoryType accessoryType)
    {
        if (accessoryInventory.ContainsKey(accessoryType))
        {
            accessoryInventory[accessoryType]++;
        }
        else
        {
            accessoryInventory.Add(accessoryType, 1);
        }

        ShowInventory() ;
    }
    private void ShowInventory()
    {
        int count = 0;
        foreach(WeaponData.WeaponType weapon in weaponInventory.Keys)
        {
            weaponSlots[count].Find("Icon").GetComponent<Image>().sprite = ItemAssets.Instance.GetWeaponData(weapon).WeaponSprite;
            weaponSlots[count].Find("Level").GetComponent<TMP_Text>().text = weaponInventory[weapon].ToString();
            count++;
        }

        count = 0;
        foreach(AccessoryData.AccessoryType accessory in accessoryInventory.Keys)
        {
            accessorySlots[count].Find("Icon").GetComponent<Image>().sprite = ItemAssets.Instance.GetAccessoryData(accessory).AccessorySprite;
            accessorySlots[count].Find("Level").GetComponent<TMP_Text>().text = accessoryInventory[accessory].ToString();
            count++;
        }
    }
}
