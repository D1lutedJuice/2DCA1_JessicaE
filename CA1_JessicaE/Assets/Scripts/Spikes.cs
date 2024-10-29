using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    //used this video for help https://www.youtube.com/watch?v=LTpvfxYOPlU

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<PlayerController>())
        {
           collision.collider.GetComponent<PlayerController>().Die();
        }
    }
}
