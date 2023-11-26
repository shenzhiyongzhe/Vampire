using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    static Dictionary<WeaponData.WeaponName, Queue<GameObject>> poolDict = new();

    [SerializeField] GameObject whip;
    [SerializeField] GameObject axe;
    [SerializeField] GameObject bible;
    [SerializeField] GameObject lightning;
    [SerializeField] GameObject magicWand;
    [SerializeField] GameObject fireWand;

    const int WeaponNum = 3;

    static ObjectPool instance;

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
                        Queue<GameObject> whipQueue = GenerateQueue(whip, WeaponData.WeaponName.Whip);
                        poolDict.Add(WeaponData.WeaponName.Whip, whipQueue);
                        break;
                    case WeaponData.WeaponName.Axe:
                        Queue<GameObject> axeQueue = GenerateQueue(axe, WeaponData.WeaponName.Axe);
                        poolDict.Add(WeaponData.WeaponName.Axe, axeQueue);
                        break;
                    case WeaponData.WeaponName.Bible:
                        Queue<GameObject> bibleQueue = GenerateQueue(bible, WeaponData.WeaponName.Bible);
                        poolDict.Add(WeaponData.WeaponName.Bible, bibleQueue);
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
                Debug.Log(name);
            }
            
        }
    }

    private Queue<GameObject> GenerateQueue(GameObject obj, WeaponData.WeaponName weaponName)
    {
        GameObject spawedObj = CreateObject(obj);
        spawedObj.SetActive(false);
        if (poolDict[weaponName] == null)
        {
            Debug.Log("do not have that key");
            return null;
        }
        if (poolDict[weaponName].Count > 0)
        {
            poolDict[weaponName].Enqueue(spawedObj);
            return poolDict[weaponName];
        }
        else
        {
            Queue<GameObject> queue = new();
            queue.Enqueue(spawedObj);
            return queue;   
        }
    }
    private GameObject CreateObject(GameObject obj)
    {
        return Instantiate(obj);
    }

    public static GameObject GetObject(WeaponData.WeaponName objName)
    {
        Queue<GameObject> objQueue = poolDict[objName];
        if (objQueue.Count > 0)
        {
            return objQueue.Dequeue();
        }
        else
        {
            return instance.CreateObject(instance.bible);
                 
        }
    }

    public static void ReturnObject(WeaponData.WeaponName objName, GameObject obj)
    {
        Queue<GameObject> objQueue = poolDict[objName];
        objQueue.Enqueue(obj);
    }
}