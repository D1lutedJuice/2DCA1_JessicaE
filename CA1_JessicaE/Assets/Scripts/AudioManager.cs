using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //used this video for help https://www.youtube.com/watch?v=N8whM1GjH4w

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip collect;
    public AudioClip powerUp;
    public AudioClip gameWin;
    public AudioClip victoryCondition;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }




   
}
