using UnityEngine;

public class PlayerDetect : MonoBehaviour


{
    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision = 20;

    public SpriteRenderer graphics;
    private Transform target;
    public bool PlayerIsDetected = false;

    // Update is called once per frame
    void Start()
    {

    }


    void Update()
    {
        target = waypoints[0];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerIsDetected = true;
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
