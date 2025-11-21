using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    public AudioClip musicClip;   // Assign your music in the Inspector
    private AudioSource audioSource;

    void Awake()
    {
        // Keep this object alive between scenes
        DontDestroyOnLoad(gameObject);

        // Add an AudioSource if one doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // Set up the AudioSource
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        // Play the music
        audioSource.Play();
    }
}

