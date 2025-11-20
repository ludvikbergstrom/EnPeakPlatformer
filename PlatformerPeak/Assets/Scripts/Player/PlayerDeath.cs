using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private GameObject respawnPoint;

    private void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("RespawnPoint");
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
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
