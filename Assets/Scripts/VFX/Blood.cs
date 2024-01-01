using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blood : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnEnable()
    {
        StartCoroutine(SetInactive());
    }
    IEnumerator SetInactive()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        ObjectPool.ReturnObject("Blood", gameObject);
    }
}
