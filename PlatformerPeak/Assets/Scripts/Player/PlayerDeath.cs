using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameObject respawnPoint;

    private void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("RespawnPoint");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathBox"))
        {
            transform.position = respawnPoint.transform.position;
        }
    }
}
