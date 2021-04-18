using UnityEngine;

public class DieZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            PlayerHealth.instance.Die();
        }
    }
}
