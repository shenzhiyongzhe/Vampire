using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    [SerializeField] RectTransform levelUpWindow;
    [SerializeField] GameObject weaponSlotTemplete;
    WeaponSlot[] weaponSlots = new WeaponSlot[slotNum];


    struct WeaponSlot
    {
        public Image weaponIcon;
        public TextMeshProUGUI weaponName;
        public TextMeshProUGUI description;
        public TextMeshProUGUI weaponLv;
        public GameObject selectedArrow;
        public Button btn;

        //public WeaponSlot(Image icon, TextMeshProUGUI name, TextMeshProUGUI desc, TextMeshProUGUI lv, GameObject selectedArrow, Button btn)
        //{
        //    weaponIcon = icon;
        //    weaponName = name;
        //    description = desc;
        //    weaponLv = lv;
        //    this.selectedArrow = selectedArrow;
        //    this.btn = btn;
        //}
    }

    const int slotNum = 3;

    private void Awake()
    {
        InstantiateWeaponSlot();
    }
    public void OnLevelUp()
    {
        ShowLevelUpWindow();
        InsertData();
    }

    void ShowLevelUpWindow()
    {
        levelUpWindow.gameObject.SetActive(true);
    }
    void InstantiateWeaponSlot()
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            RectTransform slot = Instantiate(weaponSlotTemplete, levelUpWindow).GetComponent<RectTransform>();
            slot.anchoredPosition = new Vector3(0, -i * 130f + 130, 0);

            weaponSlots[i].weaponIcon = slot.transform.Find("Weapon Icon").GetComponent<Image>();
            weaponSlots[i].weaponName = slot.transform.Find("Name").GetComponent<TextMeshProUGUI>();
            weaponSlots[i].description = slot.transform.Find("Description").GetComponent<TextMeshProUGUI>();
            weaponSlots[i].weaponLv = slot.transform.Find("Level").GetComponent<TextMeshProUGUI>();
            weaponSlots[i].selectedArrow = slot.transform.Find("Select Arrow").gameObject;
            weaponSlots[i].btn = slot.transform.Find("Button").GetComponent<Button>();
        }
    }
    void InsertData()
    {
        List<string> isDuplictated = new();
        int count = 0;
        foreach (var item in weaponSlots)
        {
            if(Random.value > 0.5f)
            {
                WeaponData weapon;
                int level = 1;
                do
                    weapon = ItemAssets.Instance.GetWeaponData(GetRandomWeapon());
                while (isDuplictated.Contains(weapon.WeaponName.ToString()));
                isDuplictated.Add(weapon.WeaponName.ToString());
                item.weaponIcon.sprite = weapon.WeaponSprite;
                item.weaponName.text = weapon.WeaponName.ToString();
                item.description.text = weapon.Description.ToString();
                item.weaponLv.text = level.ToString();
                item.selectedArrow.SetActive(count == 0);
                item.btn.onClick.RemoveAllListeners();
                item.btn.onClick.AddListener(delegate
                {
                    Inventory.Instance.AddWeapon(weapon.WeaponName);
                });
            }
            else
            {
                AccessoryData accessory;
                int level = 1;
                do
                    accessory = ItemAssets.Instance.GetAccessoryData(GetRandomAccessory());
                while (isDuplictated.Contains(accessory.AccessoryName.ToString()));
                isDuplictated.Add(accessory.AccessoryName.ToString());
                item.weaponIcon.sprite = accessory.AccessorySprite;
                item.weaponName.text=accessory.AccessoryName.ToString();
                item.description.text = accessory.AccessoryDesc.ToString();
                item.weaponLv.text = level.ToString();
                item.selectedArrow.SetActive(count == 0);
                item.btn.onClick.RemoveAllListeners();
                item.btn.onClick.AddListener(delegate
                {
                    Inventory.Instance.AddAccessory(accessory.AccessoryName);
                });
            }
            count++;
        }

    }
    WeaponData.WeaponType GetRandomWeapon()
    {
        return (WeaponData.WeaponType)Random.Range(0, System.Enum.GetValues(typeof(WeaponData.WeaponType)).Length);
    }
    AccessoryData.AccessoryType GetRandomAccessory()
    {
        return (AccessoryData.AccessoryType)Random.Range(0, System.Enum.GetValues(typeof(AccessoryData.AccessoryType)).Length); 
    }
}
