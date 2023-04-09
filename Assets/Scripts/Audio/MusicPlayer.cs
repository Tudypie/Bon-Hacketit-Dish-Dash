using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] songs;
    [SerializeField] private int currentSong = 0;

    private static MusicPlayer instance = null;

    private AudioSource audioSource;

    //Singleton Pattern
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = songs[currentSong];
        audioSource.Play();
         
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {   
            currentSong++;

            if (currentSong >= songs.Length)
                currentSong = 0;
        
            audioSource.clip = songs[currentSong];

            audioSource.Play();
        }
    }
}
