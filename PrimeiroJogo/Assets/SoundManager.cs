using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource; // Central AudioSource
    public AudioClip hitSound;
    public AudioClip scoreSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip); // Plays the sound without stopping other sounds
    }
}
