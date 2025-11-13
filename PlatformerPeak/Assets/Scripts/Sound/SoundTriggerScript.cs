using UnityEngine;

public class SoundTriggerScript : MonoBehaviour
{
    [SerializeField] private AudioClip hitSoundClip;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundFXManager.Instance.PlaySoundFXClip(hitSoundClip,transform);
        }
    }
}
