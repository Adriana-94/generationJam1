using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

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

    void ReproducirAudio(AudioClip clip)
    {
        // Solo se ejecuta una sola vez el clip de audio
        audio.PlayOneShot(clip);
    }
}
