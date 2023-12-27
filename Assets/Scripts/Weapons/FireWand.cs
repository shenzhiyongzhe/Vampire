using UnityEngine;

public class FireWand : Weapon
{

    private void OnDisable()
    {
        transform.rotation = Quaternion.identity;
    }

}