using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    private Dictionary<string, Stack<GameObject>> poolDict = new();
    
  
    const int WeaponNum = 10;
    const int EnemyNum = 10;
    const int CrystalNum = 10;
    const int DamageTxtNum = 20;

    static ObjectPool instance;
    public static ObjectPool Instance => instance;

    [SerializeField] GameObject flyingEyePrefab;
    [SerializeField] GameObject goblinPrefab;
    [SerializeField] GameObject mushroomPrefab;
    [SerializeField] GameObject skeletonPrefab;

    [SerializeField] GameObject whipPrefab;
    [SerializeField] GameObject biblePrefab;
    [SerializeField] GameObject axePrefab;
    [SerializeField] GameObject fireWandPrefab;
    [SerializeField] GameObject magicWandPrefab;
    [SerializeField] GameObject lightningPrefab;
    [SerializeField] GameObject swordPrefab;
    [SerializeField] GameObject snowFlowerPrefab;

    [SerializeField] GameObject blueCrystalPrefab;
    [SerializeField] GameObject greenCrystalPrefab;
    [SerializeField] GameObject redCrystalPrefab;

    [SerializeField] GameObject DamageText;
    [SerializeField] GameObject BloodVFX;

    private void Awake()
    {
        instance = this;
        Initialize();
    }

    void Initialize()
    {
        foreach (CharacterData.CharacterType characterType in Enum.GetValues(typeof(CharacterData.CharacterType)))
        {
            if (IsPlayer(characterType)) continue;

            Stack<GameObject> newStack = new Stack<GameObject>();

            for (int j = 0; j < EnemyNum; j++)
            {
                newStack.Push(CreateObject(characterType));
            }

            poolDict.Add(characterType.ToString(), newStack);
        }

        foreach (WeaponData.WeaponType weaponType in Enum.GetValues(typeof(WeaponData.WeaponType)))
        {
            Stack<GameObject> newStack = new Stack<GameObject>();

            for (int j = 0; j < WeaponNum; j++)
            {
                newStack.Push(CreateObject(weaponType));
            }

            poolDict.Add(weaponType.ToString(), newStack);

        }

        foreach(CrystalData.CrystalType crystalType in Enum.GetValues(typeof(CrystalData.CrystalType)))
        {
            Stack<GameObject> newStack = new Stack<GameObject>();

            for (int j = 0; j < CrystalNum; j++)
            {
                newStack.Push(CreateObject(crystalType));
            }

            poolDict.Add(crystalType.ToString(), newStack);
        }

        Stack<GameObject> damageQue = new Stack<GameObject>();

        for (int j = 0; j < DamageTxtNum; j++)
        {
            damageQue.Push(CreateObject("damage"));
        }

        poolDict.Add("damage", damageQue);

    }



    private static GameObject CreateObject<T>(T type)
    {
        GameObject newObject;
        switch (type)
        {
            case CharacterData.CharacterType.FlyingEye:
                newObject = Instantiate(instance.flyingEyePrefab, instance.transform);
                break;
            case CharacterData.CharacterType.Goblin:
                newObject = Instantiate(instance.goblinPrefab);
                break;
            case CharacterData.CharacterType.Mushroom:
                newObject = Instantiate(instance.mushroomPrefab, instance.transform);
                break;
            case CharacterData.CharacterType.Skeleton:
                newObject = Instantiate(instance.skeletonPrefab);
                break;

            case WeaponData.WeaponType.Whip:
                newObject = Instantiate(instance.whipPrefab, instance.transform);
                break;
            case WeaponData.WeaponType.Bible:
                newObject = Instantiate(instance.biblePrefab, instance.transform);
                break;
            case WeaponData.WeaponType.Axe:
                newObject = Instantiate(instance.axePrefab, instance.transform);
                break;
            case WeaponData.WeaponType.FireWand:
                newObject = Instantiate(instance.fireWandPrefab, instance.transform);
                break;
            case WeaponData.WeaponType.MagicWand:
                newObject = Instantiate(instance.magicWandPrefab, instance.transform);
                break;
            case WeaponData.WeaponType.Lightning:
                newObject = Instantiate(instance.lightningPrefab, instance.transform);
                break;
            case WeaponData.WeaponType.Sword:
                newObject = Instantiate(instance.swordPrefab, instance.transform);
                break;
            case WeaponData.WeaponType.SnowFlower:
                newObject = Instantiate(instance.snowFlowerPrefab, instance.transform);
                break;


            case CrystalData.CrystalType.BlueCrystal:
                newObject = Instantiate(instance.blueCrystalPrefab, instance.transform); break;
            case CrystalData.CrystalType.GreenCrystal:
                newObject = Instantiate(instance.greenCrystalPrefab, instance.transform); break;
            case CrystalData.CrystalType.RedCrystal:
                newObject = Instantiate(instance.redCrystalPrefab, instance.transform); break;

            case "damage":
                newObject = Instantiate(instance.DamageText, instance.transform); break;
            case "Blood":
                newObject = Instantiate(instance.BloodVFX, Player.Instance.transform); break;

            default:newObject = null;
                break;
        }
        newObject.SetActive(false);
        return newObject;
    }

    public static GameObject GetObject<T>(T type)
    {
        if (instance.poolDict.ContainsKey(type.ToString()) && instance.poolDict[type.ToString()].Count > 0)
        {
            return instance.poolDict[type.ToString()].Pop();
        }
        else 
            return CreateObject(type);         
    }

    public static void ReturnObject<T>(T type, GameObject obj)
    {
        if (instance.poolDict.ContainsKey(type.ToString()))
        {
            instance.poolDict[type.ToString()].Push(obj);
        }
        else
        {
            Stack<GameObject> objStack = new();
            objStack.Push(obj);
            instance.poolDict.Add(type.ToString(), objStack);
        }
       
    }

    bool IsPlayer(CharacterData.CharacterType characterType)
    {
        switch (characterType)
        {
            case CharacterData.CharacterType.Knight:
            case CharacterData.CharacterType.Bandit:
                return true;
            default:
                return false;
        }
    }
}



