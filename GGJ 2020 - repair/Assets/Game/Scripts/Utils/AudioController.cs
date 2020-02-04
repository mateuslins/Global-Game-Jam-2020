using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioSource musicSource;

    public AudioClip sfxFixTower;
    public AudioClip sfxPick;
    public AudioClip sfxEnemyDied;
    public AudioClip sfxPlayerDied;
    public AudioClip sfxTowerShoot;


    void Awake()
    {
         DontDestroyOnLoad(this.gameObject);   
    }
    private void Start()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
    public void playSfx(AudioClip sfxClip,float volume)
    {
        sfxSource.PlayOneShot(sfxClip, volume);
    }
}
