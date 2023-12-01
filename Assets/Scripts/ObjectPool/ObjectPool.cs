﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    static Dictionary<WeaponData.WeaponName, Queue<GameObject>> poolDict = new();
    public List<WeaponDict> weaponList;
  
    const int WeaponNum = 10;

    static ObjectPool instance;

    [SerializeField] Transform whipSpawner;
    [SerializeField] Transform axeSpawner;
    [SerializeField] Transform bibleSpawner;
    private void Awake()
    {
        instance = this;
        Initialize();
    }

    void Initialize()
    {   
        for (int i = 0; i < WeaponNum; i++)
        {
            foreach(WeaponData.WeaponName name in Enum.GetValues(typeof(WeaponData.WeaponName)))
            {
                switch (name)
                {
                    case WeaponData.WeaponName.Whip:
                        InitQueue(weaponList[0].weaponPrefab, name, whipSpawner);
                        break;
                    case WeaponData.WeaponName.Axe:
                        InitQueue(weaponList[1].weaponPrefab, name, axeSpawner);
                        break;
                    case WeaponData.WeaponName.Bible:
                        InitQueue (weaponList[2].weaponPrefab, name, bibleSpawner);
                        break;
                    case WeaponData.WeaponName.Lightning:
                        break;
                    case WeaponData.WeaponName.MagicWand:
                        break;
                    case WeaponData.WeaponName.FireWand:
                        break;
                    default:
                        break;
                }
            }
            
        }
    }


    private void InitQueue(GameObject obj, WeaponData.WeaponName weaponName, Transform objParent)
    {
        GameObject spawedObj = CreateObject(obj, objParent);
        spawedObj.SetActive(false);
        if (!poolDict.ContainsKey(weaponName))
        {
            Queue<GameObject> queue = new();
            queue.Enqueue(spawedObj);
            poolDict.Add(weaponName, queue);
        }
        else 
        {
            poolDict[weaponName].Enqueue(spawedObj);
        }

    }
    private GameObject CreateObject(GameObject obj, Transform objParent)
    {
        return Instantiate(obj, objParent);
    }

    public static GameObject GetObject(WeaponData.WeaponName objName, Transform objParent)
    {
        Queue<GameObject> objQueue = poolDict[objName];
        if (poolDict.ContainsKey(objName) && poolDict[objName].Count > 0)
        {
            return objQueue.Dequeue();
        }
        else
        {
            var wpList = from weapon in instance.weaponList where weapon.weaponName == objName select weapon;
            GameObject obj = instance.CreateObject(wpList.ToArray()[0].weaponPrefab, objParent);

            return obj;  
        }
    }

    public static void ReturnObject(WeaponData.WeaponName objName, GameObject obj)
    {
        if (poolDict.ContainsKey(objName))
        {
            poolDict[objName].Enqueue(obj);
        }
        else if(!poolDict.ContainsKey(objName))
        {
            Queue<GameObject> objQueue = poolDict[objName];
            poolDict.Add(objName, objQueue);
        }
        
    }
}

[System.Serializable]
public struct WeaponDict
{
    public WeaponData.WeaponName weaponName;
    public GameObject weaponPrefab;
}