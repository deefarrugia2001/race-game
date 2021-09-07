using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicPlayer : MonoBehaviour, ISingleton
{
    static List<MusicPlayer> musicPlayerInstances;
    [SerializeField] AudioClip backgroundMusic;
    AudioSource audioSource;

    void Awake()
    {
        ImplementSingleton();
    }

    public void ImplementSingleton() 
    {
        musicPlayerInstances = FindObjectsOfType<MusicPlayer>().ToList();
        if (musicPlayerInstances.Count > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if(audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }
}