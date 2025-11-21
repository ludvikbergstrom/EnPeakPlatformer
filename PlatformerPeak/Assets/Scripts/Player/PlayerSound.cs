using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;
    [SerializeField] private float volumeLand;
    [SerializeField] private float volumeJump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Surface"))
        {
            SoundFXManager.Instance.PlaySoundFXClip(landSound, transform,volumeLand);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (SceneController.instance.ChangingScene) return;


        if (collision.CompareTag("Surface"))
        {
            SoundFXManager.Instance.PlaySoundFXClip(jumpSound, transform,volumeJump);
        }
    }
}
