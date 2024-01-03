using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="Accessory Data", menuName ="Scriptable Object/Accessory Data")]
public class AccessoryData : ScriptableObject
{
    [SerializeField] AccessoryType accessoryType;
    [SerializeField] Sprite accessorySprite;
    [SerializeField] string accessoryDesc;


    public enum AccessoryType
    {
        Spinach, Armor, EmptyTome, Wings, Clover, Crown, FlightSpeed
    }

    public AccessoryType AccessoryName => accessoryType;

    public Sprite AccessorySprite => accessorySprite;
    public string AccessoryDesc => accessoryDesc;
}
