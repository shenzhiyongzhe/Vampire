using UnityEngine;

public class Lightning : Weapon
{
    private void OnDisable()
    {
        transform.localScale = Vector3.one;
    }



}