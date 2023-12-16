using UnityEngine;


public class Whip : Weapon
{
    private void OnDisable()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }

}
