using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public int Coin = 5;
    public int Collected = 0;

    public AudioClip Effect;

    public void Start()
    {
        if (Collected == 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(Effect, transform.position);
            CointInventory.instance.AddCoins(Coin);
            LoadAndSaveData.instance.SaveData();
            Destroy(gameObject);
            Collected = 1;

        }
    }
}
