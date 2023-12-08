using System.Collections;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [SerializeField] Transform weaponSlotTemplate;
    [SerializeField] Transform weaponSlotParent;
    [SerializeField] Transform accessoryTemplate;
    [SerializeField] Transform accessoryParent;

    RectTransform[] weaponSlots = new RectTransform[slotNum];
    RectTransform[] accessorySlots = new RectTransform[slotNum];

    WeaponSpawner bible;

    const int slotNum = 6;
    const float slotSize = 30f;

    private void Awake()
    {
        SlotInitialise();
        bible = GetComponent<BibleSpawner>();
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
}
