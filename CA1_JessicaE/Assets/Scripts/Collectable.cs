using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] PlayerController player; //serialize player so we can call from playercontroler

    // Start is called before the first frame update
    void Start()
    {        
         player=GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when player colides with the object fish, it gets destroyed
        if(collision.gameObject.tag== "Player" && this.tag=="Fish")
        {
            Destroy(this.gameObject);
            //Calls method from playerController
            player.AddFish();
        }
    }
}
