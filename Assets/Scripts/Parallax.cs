using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float startPos;
    private GameObject cam;
    private float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
    }

    void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
