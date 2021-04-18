﻿using UnityEngine;

public class EnemyPatrolv3 : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision = 20;

    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;
    public bool PlayerIsDetected = false;
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsDetected == false)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            // Si l'ennemi est quasiment arrivé à sa destination
            if (Vector3.Distance(transform.position, target.position) < 0.3f)
            {
                destPoint = (destPoint + 1) % waypoints.Length;
                target = waypoints[destPoint];
                graphics.flipX = !graphics.flipX;
            }
        }
    }
}
