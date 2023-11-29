using UnityEngine;

public class Bible : MonoBehaviour
{
    [SerializeField] float speed;
    private Transform playerPos;
    private void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        transform.RotateAround(playerPos.position, Vector3.forward, speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -1), speed * Time.deltaTime);
    }

}