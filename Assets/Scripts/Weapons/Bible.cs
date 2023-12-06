using UnityEngine;

public class Bible : Weapon
{
    private Transform playerPos;

    private void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        transform.RotateAround(playerPos.position, Vector3.forward, attackSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -1), attackSpeed * Time.deltaTime);
    }

}