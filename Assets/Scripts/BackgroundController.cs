using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BackgroundController : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float move = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (move > startpos + length)
        {
            startpos += length;
        }
        else if (move < startpos - length)
        {
            startpos -= length;
        }
    }
}
