using System.Collections;
using UnityEngine;

public class TravelStart : MonoBehaviour

{
    public GameObject Player;
    public static TravelStart instance;
    public GameObject Camera;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Camera.GetComponent<CameraFollow>().enabled = false;
        Player.GetComponent<TravelObject>().enabled = false;
    }
    public IEnumerator StartTravel()
    {
        Player.GetComponent<TravelObject>().enabled = true;
        yield return new WaitForSeconds(1f);
        Camera.GetComponent<CameraFollow>().enabled = true;

    }
}
