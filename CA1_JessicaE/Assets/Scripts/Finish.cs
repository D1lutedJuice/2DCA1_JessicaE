using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour

{

     [SerializeField] PlayerController player;
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        { 
            player.Finish();
        }
         

   }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            UIManager.Instance.HideVictoryCondition();
        }
    }
}
