using UnityEngine;

public class Border : MonoBehaviour
{
    public static Border instance;
    public float speed;

    public Transform[] waypoints;

    private Transform target;
    private int destPoint = 0;
    public float decalage;

    public void Start()
    {
        target = waypoints[0];
        this.transform.position = new Vector3(CurrentSceneManager.instance.RespawnPoint.x - 15, CurrentSceneManager.instance.RespawnPoint.y, CurrentSceneManager.instance.RespawnPoint.z);
    }

    public void Awake()
    {
        instance = this;
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arrivé à sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }

}
