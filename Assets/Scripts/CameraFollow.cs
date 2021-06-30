using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    public static CameraFollow instance;
    private Vector3 velocity;
    public bool active = true;


    public void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(active)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset,
                ref velocity, timeOffset);
        }

    }
}
