using TMPro;
using UnityEngine;

public class Bible : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int attackDamage;
    [SerializeField] GameObject TMP_damagePoint;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            GameObject obj = Instantiate(TMP_damagePoint, collision.transform.position + Vector3.up, Quaternion.identity);
            obj.GetComponent<TextMeshPro>().text = attackDamage.ToString();
            Destroy(obj, 1);
            //Debug.Log("catch you");
        }
    }
}