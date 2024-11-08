using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
     
     [SerializeField] PlayerController player; //serialize player so we can call from playercontroler
      AudioManager audioManager; //set the audiomanager so we can call from it

    // Start is called before the first frame update
    void Start()
    {
          player=GameObject.Find("Player").GetComponent<PlayerController>();
          audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

     private void OnTriggerEnter2D(Collider2D collision) //on collision
    {
        if(collision.gameObject.tag== "Player" && this.tag=="Clock") //if object tagged player collides with object with tag clock
        {
            Destroy(this.gameObject);//destroys the object
            Timer.Instance.AddPowerUpTime();//calls the powerup Method in our Timer using instance 
            audioManager.PlaySFX(audioManager.powerUp); // calls the PlaySFX method to play the powerUp sound effect
        }
    }
}
