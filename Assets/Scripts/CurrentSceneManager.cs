using System;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public Vector3 RespawnPoint;
    public static CurrentSceneManager instance;
    public bool isTheFirstEnterInLevel = true;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène");
            return;
        }

        instance = this;
    }

    public void UpdatePos(GameObject Checkpoint)
    {
        RespawnPoint.x = Checkpoint.GetComponent<Transform>().transform.position.x;
        RespawnPoint.y = Checkpoint.GetComponent<Transform>().transform.position.y;
        RespawnPoint.z = Checkpoint.GetComponent<Transform>().transform.position.z;
    }

    public void SetRespawnPoint(Vector3 Positions)
    {
        var NewRespawnPoint = RespawnPoint;
       NewRespawnPoint.x = Positions.x;
       NewRespawnPoint.y = Positions.y;
       NewRespawnPoint.z = Positions.z;
       RespawnPoint = NewRespawnPoint;
        
       
    }
}
