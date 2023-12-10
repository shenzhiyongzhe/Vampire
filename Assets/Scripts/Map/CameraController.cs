using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    private void Start()
    {
        target = PlayerMove.Instance.transform;
    }

    void Update()
    {
        if (target != null) {
            transform.position = new Vector3(target.position.x, target.position.y, -10);
        }

    }
}
