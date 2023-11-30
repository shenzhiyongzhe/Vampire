using Unity.VisualScripting;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.AddForce(new Vector2(15,15));
        transform.SetParent(null);
    }

}