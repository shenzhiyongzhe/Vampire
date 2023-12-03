using Assets.Scripts;
using Assets.Scripts.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Assets.Scripts.Character.CharacterData;


public class ObjectPool : MonoBehaviour
{
    private Dictionary<string, Queue<GameObject>> poolDict = new();
    
  
    const int WeaponNum = 10;
    const int EnemyNum = 10;
    const int damageTxtNum = 10;

    static ObjectPool instance;

    [SerializeField] GameObject flyingEyePrefab;
    //[SerializeField] GameObject goblinPrefab;
    [SerializeField] GameObject mushroomPrefab;
    //[SerializeField] GameObject skeletonPrefab;

    [SerializeField] GameObject whipPrefab;
    [SerializeField] GameObject biblePrefab;
    //[SerializeField] GameObject axePrefab;
    //[SerializeField] GameObject pigeonPrefab;
    //[SerializeField] GameObject lightningPrefab;
    //[SerializeField] GameObject magicWandPrefab;

    //[SerializeField] GameObject blueCrystalPrefab;
    //[SerializeField] GameObject greenCrystalPrefab;
    //[SerializeField] GameObject redCrystalPrefab;

    [SerializeField] GameObject DamageText;
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
            Debug.Log(weaponType.ToString());

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
                newObject = Instantiate(instance.flyingEyePrefab);
                break;
            //case CharacterData.CharacterType.Goblin:
            //    newObject = Instantiate(instance.goblinPrefab);
            //    break;
            case CharacterData.CharacterType.Mushroom:
                newObject = Instantiate(instance.mushroomPrefab);
                break;
            //case CharacterData.CharacterType.Skeleton:
            //    newObject = Instantiate(instance.skeletonPrefab);
            //    break;

            //case WeaponData.WeaponType.Whip:
            //    newObject = Instantiate(instance.whipPrefab);
            //    break;
            case WeaponData.WeaponType.Bible:
                newObject = Instantiate(instance.biblePrefab);
                break;

            case "damage":
                newObject = Instantiate(instance.DamageText); break;
            default:newObject = null;
                break;
        }
        newObject.SetActive(false);
        return newObject;
    }

    public static GameObject GetObject<T>(T type)
    {
        if (instance.poolDict[type.ToString()].Count > 0)
            return instance.poolDict[type.ToString()].Dequeue();
        else 
            return CreateObject(type);         
    }

    public static void ReturnObject<T>(T _type, GameObject obj)
    {
        string type = _type.ToString();

        if (instance.poolDict.ContainsKey(type))
        {
            instance.poolDict[type].Enqueue(obj);
        }
        else
        {
            Queue<GameObject> objQueue = new();
            objQueue.Enqueue(obj);
            instance.poolDict.Add(type, objQueue);
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



