using UnityEngine;

public class Bible : Weapon
{
    private void Update()
    {
        transform.RotateAround(PlayerMoveIns.transform.position, Vector3.forward, 1024 * AttackSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -1), 1024 * AttackSpeed * Time.deltaTime);
    }
}