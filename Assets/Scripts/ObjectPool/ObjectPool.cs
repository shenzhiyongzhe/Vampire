using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    static Dictionary<WeaponData.WeaponName, Queue<GameObject>> poolDict = new();
    public List<WeaponDict> weaponList;
  
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
                        AddObjToQueue(weaponList[0].weaponPrefab, name);
                        break;
                    case WeaponData.WeaponName.Axe:
                        AddObjToQueue(weaponList[1].weaponPrefab, name);
                        break;
                    case WeaponData.WeaponName.Bible:
                        AddObjToQueue (weaponList[2].weaponPrefab, name);
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

    void ShowInspector()
    {
        //for(int i = 0; i < weaponList.Length; i++)
        //{

        //}
    }
    private void AddObjToQueue(GameObject obj, WeaponData.WeaponName weaponName)
    {
        GameObject spawedObj = CreateObject(obj);
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
    private GameObject CreateObject(GameObject obj)
    {
        return Instantiate(obj);
    }

    public static GameObject GetObject(WeaponData.WeaponName objName)
    {
        Queue<GameObject> objQueue = poolDict[objName];
        if (poolDict.ContainsKey(objName))
        {
            return objQueue.Dequeue();
        }
        else
        {
            WeaponData .WeaponName name 
            GameObject obj =  instance.CreateObject(instance.axe);
            obj.SetActive(false);
            Queue<GameObject> queue = new();
            queue.Enqueue(obj);
            poolDict.Add(objName, queue);
            return obj;
                 
        }
    }

    public static void ReturnObject(WeaponData.WeaponName objName, GameObject obj)
    {
        Queue<GameObject> objQueue = poolDict[objName];
        objQueue.Enqueue(obj);
    }
}

[System.Serializable]
public struct WeaponDict
{
    public WeaponData.WeaponName weaponName;
    public GameObject weaponPrefab;
}