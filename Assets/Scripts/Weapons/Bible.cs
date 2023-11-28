using UnityEngine;

public class Bible : MonoBehaviour
{
    [SerializeField] float radius;
    float arc;
    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    private void Update()
    {
        arc += Time.deltaTime;
        pos = new Vector3(Mathf.Cos(arc) * radius, Mathf.Sin(arc) * radius, transform.position.z);
        transform.position = pos;
    }
}