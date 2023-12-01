using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCase : MonoBehaviour
{
    float num;
    //protected float a = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        GetNum(num);
    }

    public void GetNum(float num)
    {
        this.num = num;
        Debug.Log($"parent/Child num:{num}");
    }
}
