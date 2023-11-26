using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    static Dictionary<WeaponData.WeaponName, Queue<GameObject>> poolDict = new();

    [SerializeField] GameObject bible;
    [SerializeField] GameObject axe;
    const int WeaponNum = 10;

    static ObjectPool instance;

    private void Awake()
    {
        instance = this;
        Initialize();
    }

    void Initialize()
    {
        Queue<GameObject> bibleQueue = new Queue<GameObject>();
        for (int i = 0; i < WeaponNum; i++)
        {
            GameObject obj = CreateObject(bible);
            bibleQueue.Enqueue(obj); 
            obj.SetActive(false);
        }
        poolDict.Add(WeaponData.WeaponName.Bible, bibleQueue);

        Queue<GameObject> axeQueue = new();
        for(int i = 0;i < WeaponNum; i++)
        {
            GameObject obj = CreateObject(axe);
            axeQueue.Enqueue(obj);
            obj.SetActive(false);
        }
        poolDict.Add(WeaponData.WeaponName.Axe, axeQueue);
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