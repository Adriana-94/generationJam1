using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource musicSource, effectsSource;
    public AudioMixer master;
    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }
    public void ReproducirAudio(AudioClip music)
    {
        musicSource.Stop();
        musicSource.clip = music;
        musicSource.Play();
        musicSource.loop = true;
    }
}
