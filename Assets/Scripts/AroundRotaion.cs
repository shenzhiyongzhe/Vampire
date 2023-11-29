using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundRotaion : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.forward, rotationSpeed);
    }
}
