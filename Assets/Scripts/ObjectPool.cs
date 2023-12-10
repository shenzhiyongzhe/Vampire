using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    private Dictionary<string, Queue<GameObject>> poolDict = new();
    
  
    const int WeaponNum = 10;
    const int EnemyNum = 10;
    const int CrystalNum = 10;
    const int damageTxtNum = 20;

    static ObjectPool instance;

    [SerializeField] GameObject flyingEyePrefab;
    //[SerializeField] GameObject goblinPrefab;
    [SerializeField] GameObject mushroomPrefab;
    //[SerializeField] GameObject skeletonPrefab;

    [SerializeField] GameObject whipPrefab;
    [SerializeField] GameObject biblePrefab;
    [SerializeField] GameObject axePrefab;
    [SerializeField] GameObject fireWandPrefab;
    [SerializeField] GameObject magicWandPrefab;
    [SerializeField] GameObject lightningPrefab;

    [SerializeField] GameObject blueCrystalPrefab;
    [SerializeField] GameObject greenCrystalPrefab;
    [SerializeField] GameObject redCrystalPrefab;

    [SerializeField] GameObject DamageText;

    [SerializeField] Transform weaponPool;
    [SerializeField] Transform crystalPool;
    [SerializeField] Transform enemyPool;
    [SerializeField] Transform meleeWeapon;
    [SerializeField] Transform damageTxtPool;
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

            Queue<GameObject> newQue = new Queue<GameObject>();

            for (int j = 0; j < EnemyNum; j++)
            {
                newQue.Enqueue(CreateObject(characterType));
            }

            poolDict.Add(characterType.ToString(), newQue);
        }

        foreach (WeaponData.WeaponType weaponType in Enum.GetValues(typeof(WeaponData.WeaponType)))
        {
            Queue<GameObject> newQue = new Queue<GameObject>();

            for (int j = 0; j < WeaponNum; j++)
            {
                newQue.Enqueue(CreateObject(weaponType));
            }

            poolDict.Add(weaponType.ToString(), newQue);

        }

        foreach(CrystalData.CrystalType crystalType in Enum.GetValues(typeof(CrystalData.CrystalType)))
        {
            Queue<GameObject> newQue = new Queue<GameObject>();

            for (int j = 0; j < CrystalNum; j++)
            {
                newQue.Enqueue(CreateObject(crystalType));
            }

            poolDict.Add(crystalType.ToString(), newQue);
        }

        Queue<GameObject> damageQue = new Queue<GameObject>();

        for (int j = 0; j < damageTxtNum; j++)
        {
            damageQue.Enqueue(CreateObject("damage"));
        }

        poolDict.Add("damage", damageQue);

    }



    private static GameObject CreateObject<T>(T type)
    {
        GameObject newObject;
        switch (type)
        {
            case CharacterData.CharacterType.FlyingEye:
                newObject = Instantiate(instance.flyingEyePrefab, instance.enemyPool);
                break;
            //case CharacterData.CharacterType.Goblin:
            //    newObject = Instantiate(instance.goblinPrefab);
            //    break;
            case CharacterData.CharacterType.Mushroom:
                newObject = Instantiate(instance.mushroomPrefab, instance.enemyPool);
                break;
            //case CharacterData.CharacterType.Skeleton:
            //    newObject = Instantiate(instance.skeletonPrefab);
            //    break;

            case WeaponData.WeaponType.Whip:
                newObject = Instantiate(instance.whipPrefab, instance.weaponPool);
                break;
            case WeaponData.WeaponType.Bible:
                newObject = Instantiate(instance.biblePrefab, instance.meleeWeapon);
                break;
            case WeaponData.WeaponType.Axe:
                newObject = Instantiate(instance.axePrefab, instance.weaponPool);
                break;
            case WeaponData.WeaponType.FireWand:
                newObject = Instantiate(instance.fireWandPrefab, instance.weaponPool);
                break;
            case WeaponData.WeaponType.MagicWand:
                newObject = Instantiate(instance.magicWandPrefab, instance.weaponPool);
                break;
            case WeaponData.WeaponType.Lightning:
                newObject = Instantiate(instance.lightningPrefab, instance.weaponPool);
                break;


            case CrystalData.CrystalType.BlueCrystal:
                newObject = Instantiate(instance.blueCrystalPrefab, instance.crystalPool); break;
            case CrystalData.CrystalType.GreenCrystal:
                newObject = Instantiate(instance.greenCrystalPrefab, instance.crystalPool); break;
            case CrystalData.CrystalType.RedCrystal:
                newObject = Instantiate(instance.redCrystalPrefab, instance.crystalPool); break;

            case "damage":
                newObject = Instantiate(instance.DamageText, instance.damageTxtPool); break;
            default:newObject = null;
                break;
        }
        newObject.SetActive(false);
        return newObject;
    }

    public static GameObject GetObject<T>(T type)
    {
        if (instance.poolDict[type.ToString()].Count > 0)
        {
            return instance.poolDict[type.ToString()].Dequeue();
        }
        else 
            return CreateObject(type);         
    }

    public static void ReturnObject<T>(T type, GameObject obj)
    {
        if (instance.poolDict.ContainsKey(type.ToString()))
        {
            instance.poolDict[type.ToString()].Enqueue(obj);
        }
        else
        {
            Queue<GameObject> objQueue = new();
            objQueue.Enqueue(obj);
            instance.poolDict.Add(type.ToString(), objQueue);
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



