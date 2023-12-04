using System.Collections;
using UnityEngine;


public class Crystal : MonoBehaviour
{
    [SerializeField] CrystalData crystalData;

    int exp;
    CrystalData.CrystalType crystalType;
    public int Exp => exp;

    public CrystalData.CrystalType GetCrystalType() => crystalType;
    private void Awake()
    {
        exp = crystalData.GetExp();
        crystalType = crystalData.GetCrystalType();
    }

}