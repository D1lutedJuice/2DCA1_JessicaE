using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //used this video for help script audio https://www.youtube.com/watch?v=N8whM1GjH4w
    

    //variables for each sound effect so we can call it in other classes
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
        //on start plays the background music
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);//plays the sound effect
    }
}
