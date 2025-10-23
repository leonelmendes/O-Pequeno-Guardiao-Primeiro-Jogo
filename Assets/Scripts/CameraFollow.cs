using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public bool followY = false;

    void LateUpdate()
    {
        offset = new Vector3(2, 1.5f, -10);
        Vector3 newPos = target.position + offset;

        if (!followY)
            newPos.y = transform.position.y;

        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
