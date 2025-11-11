using UnityEngine;

public class SoundObjectScript : MonoBehaviour
{
    public AudioClip audioClip;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            AudioSource.PlayClipAtPoint(audioClip,transform.position);
            Destroy(gameObject);
        }
    }
}
