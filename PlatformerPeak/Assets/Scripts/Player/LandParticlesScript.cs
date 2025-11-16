using UnityEngine;

public class LandParticlesScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem landParticles;
    private ParticleSystem landParticlesInstance;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Surface"))
        {
                SpawnLandParticles();
        }
    }
    private void SpawnLandParticles()
    {
        landParticlesInstance = Instantiate(landParticles, transform.position - new Vector3(0f,0.4f,0f), Quaternion.identity); 
    }
}
