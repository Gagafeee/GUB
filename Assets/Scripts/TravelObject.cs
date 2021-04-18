using UnityEngine;

public class TravelObject : MonoBehaviour
{
    public float speed;
    public Transform[] point;


    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        target = point[0];

    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arrivé à sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % point.Length;
            target = point[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

}
