using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsPicker : MonoBehaviour
{
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Props")
        {
            int exp = collision.GetComponent<Crystal>().Exp;
            player.PlayerExp += exp;

            ObjectPool.ReturnObject(collision.GetComponent<Crystal>().GetCrystalType(), collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
