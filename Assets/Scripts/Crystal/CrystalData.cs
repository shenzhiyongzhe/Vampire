
using UnityEngine;

[CreateAssetMenu(fileName ="Crystal Data", menuName ="Scriptable/Crystal Data")]
public class CrystalData: ScriptableObject
{
    public enum CrystalType
    {
        BlueCrystal, GreenCrystal, RedCrystal
    }
    [SerializeField] CrystalType crystalType;
    [SerializeField] int exp;

    public CrystalType GetCrystalType() { return crystalType; }
    public int GetExp() { return exp; }
}