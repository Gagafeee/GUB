using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public int damageOnCollision = 20;
    private Animator fadeSystem;
    public GameObject chekpoint;
    private void Awake()
    {

        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement.instance.Player.GetComponent<Animator>().enabled = false;
            PlayerMovement.instance.enabled = false;
            StartCoroutine(ReplacePlayer(collision));

        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = CurrentSceneManager.instance.RespawnPoint;
        PlayerMovement.instance.Player.GetComponent<Animator>().enabled = true;
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
            PlayerMovement.instance.enabled = true;
        }
    }
}
