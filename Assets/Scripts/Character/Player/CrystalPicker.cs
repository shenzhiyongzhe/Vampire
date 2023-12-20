using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPicker : MonoBehaviour
{
    [SerializeField] Player player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Props")
        {
            int exp = collision.GetComponent<Crystal>().Exp;
            player.GetExp(exp * (int)player.ExpBuff);

            ObjectPool.ReturnObject(collision.GetComponent<Crystal>().GetCrystalType(), collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
