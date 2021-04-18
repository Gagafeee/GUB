using UnityEngine;

public class EnemyPatrolv2 : MonoBehaviour
{
    private Transform target;
    public float speed;
    public Transform[] waypoints;

    void Start()
    {
        target = waypoints[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    }


}

