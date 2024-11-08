using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour

{
    
     [SerializeField] PlayerController player; //serialize player so we can call from playercontroler


   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") //if player colides with the object
        { 
            player.Finish();//calls the finish method in playercontroller
        }
   }
    
    private void OnTriggerExit2D(Collider2D collision)//when player exits the collision
    {
        if(collision.tag == "Player") // if player colides with object
        {
            //calls the hideVictoryCondition from UIManager using the Instance
            UIManager.Instance.HideVictoryCondition();
        }
    }
}
