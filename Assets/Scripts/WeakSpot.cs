using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Destroy(objectToDestroy);
            CointInventory.instance.AddCoins(15);
        }
    }
}
