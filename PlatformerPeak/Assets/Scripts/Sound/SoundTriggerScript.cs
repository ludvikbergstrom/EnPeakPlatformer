using UnityEngine;

public class SoundTriggerScript : MonoBehaviour
{
    [SerializeField] private AudioClip hitSoundClip;
    private Animator explosionAnimator;
    private SpriteRenderer andreasImage;

    private void Start()
    {
        andreasImage = GetComponent<SpriteRenderer>();
        explosionAnimator = GetComponentInChildren<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundFXManager.Instance.PlaySoundFXClip(hitSoundClip,transform,0.13f);
            andreasImage.enabled = false;
            explosionAnimator.SetTrigger("AndreasExplosion");
            Invoke("DestroyAndreas", 0.5f);
        }
    }

    private void DestroyAndreas()
    {
        Destroy(gameObject);
    }
}
