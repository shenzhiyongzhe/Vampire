using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlower : Weapon
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().AddDebuff_Despeed();
        }
    }

    float gap = 0.5f;
    float curTime = 0f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        curTime += Time.deltaTime;
        if(collision.CompareTag("Enemy") && curTime >= gap)
        {
            collision.GetComponent<Enemy>().AddDebuff_Despeed();
            curTime = 0f;
        }
    }
}
