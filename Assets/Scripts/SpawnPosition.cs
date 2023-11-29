using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    [SerializeField] GameObject circle;
    [SerializeField] float radius;
    [SerializeField] float speed;
    [SerializeField] int num;
    // Start is called before the first frame update
    void Start()
    {
        SetPostion();
    }

    void SetPostion()
    {
        for(int i = 0; i < num; i++)
        {
            GameObject obj = Instantiate(circle, transform);
            obj.transform.position = new Vector3(Mathf.Cos(2 * Mathf.PI / num * (i + 1)) * radius, Mathf.Sin(2*Mathf.PI / num * (i + 1)) * radius, 0) + transform.position;
        }
    }
}
