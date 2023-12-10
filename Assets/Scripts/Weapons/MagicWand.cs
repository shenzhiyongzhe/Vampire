using UnityEngine;

public class MagicWand : Weapon
{
    private void Update()
    {
        transform.RotateAround(Player.position, Vector3.forward, attackSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -1), attackSpeed * Time.deltaTime);
    }

}