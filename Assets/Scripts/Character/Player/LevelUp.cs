using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    [SerializeField] RectTransform levelUpWindow;
    [SerializeField] GameObject weaponSlotTemplete;
    [SerializeField] TMP_Text lvText;
    WeaponSlot[] weaponSlots = new WeaponSlot[slotNum];
    //bool levelUpTime = false;


    struct WeaponSlot
    {
        public Image weaponIcon;
        public TextMeshProUGUI weaponName;
        public TextMeshProUGUI description;
        public TextMeshProUGUI weaponLv;
        public GameObject selectedArrow;
        public UnityEngine.UI.Button btn;
    }

    const int slotNum = 3;

    private void Awake()
    {
        InstantiateWeaponSlot();
    }
    public void OnLevelUp()
    {
        Player.Instance.PlayerLv++;
        levelUpWindow.gameObject.SetActive(true);
        InsertData();
        lvText.text = $"等级：{Player.Instance.PlayerLv}";
        Time.timeScale = 0;
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
            weaponSlots[i].btn = slot.transform.Find("Button").GetComponent<UnityEngine.UI.Button>();
        }
    }
    void InsertData()
    {
        List<string> isDuplictated = new();
        foreach (var item in weaponSlots)
        {
            if(Random.value > 0.5f)
            {
                WeaponData weapon;
                int level = 1;
                do
                    weapon = ItemAssets.Instance.GetWeaponData(GetRandomWeapon());
                while (isDuplictated.Contains(weapon.WeaponName.ToString()) || (Inventory.WeaponInventory.ContainsKey(weapon.WeaponName) && Inventory.WeaponInventory[weapon.WeaponName] >= 9));
                     
                   
                isDuplictated.Add(weapon.WeaponName.ToString());
                item.weaponIcon.sprite = weapon.WeaponSprite;
                item.weaponName.text = weapon.WeaponName.ToString();
                item.description.text = weapon.Description.ToString();
                item.weaponLv.text = level.ToString();
                item.selectedArrow.SetActive(false);
                item.btn.onClick.RemoveAllListeners();
                item.btn.onClick.AddListener(delegate
                {
                    Inventory.Instance.AddWeapon(weapon.WeaponName);
                    levelUpWindow.gameObject.SetActive(false);
                    Time.timeScale = 1;
                });
            }
            else
            {
                AccessoryData accessory;
                int level = 1;
                do
                    accessory = ItemAssets.Instance.GetAccessoryData(GetRandomAccessory());
                while (isDuplictated.Contains(accessory.AccessoryName.ToString()) || (Inventory.AccessoryInventory.ContainsKey(accessory.AccessoryName) && Inventory.AccessoryInventory[accessory.AccessoryName] >= 6));
                isDuplictated.Add(accessory.AccessoryName.ToString());
                item.weaponIcon.sprite = accessory.AccessorySprite;
                item.weaponName.text=accessory.AccessoryName.ToString();
                item.description.text = accessory.AccessoryDesc.ToString();
                item.weaponLv.text = level.ToString();
                item.selectedArrow.SetActive(false);
                item.btn.onClick.RemoveAllListeners();
                item.btn.onClick.AddListener(delegate
                {
                    Inventory.Instance.AddAccessory(accessory.AccessoryName);
                    levelUpWindow.gameObject.SetActive(false);
                    Time.timeScale = 1;
                });
            }
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
