using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public AudioClip chequed;
    public GameObject respawnPoint;
    public static Checkpoint instance;

    public void Awake()
    {
        instance = this;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(chequed, transform.position);
            CurrentSceneManager.instance.UpdatePos(this.gameObject);

            CurrentSceneManager.instance.SetRespawnPoint(this.gameObject.transform.position);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            CurrentSceneManager.instance.isTheFirstEnterInLevel = false;
            LoadAndSaveData.instance.SaveData();
        }
    }
}
