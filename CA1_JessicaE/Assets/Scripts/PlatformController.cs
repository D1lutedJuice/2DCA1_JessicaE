using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour

{
    //used this video to help with code https://www.youtube.com/watch?v=GtX1p4cwYOc
    //variables
    public float speed; //platform speed
    public int startPoint; // starting position
    public Transform[] points; // array of points wich platform needs to move
    private int i; 

    void Start()
    {
        transform.position = points[startPoint].position; //setting start position to the start point index
    }

    private void Update()
    {
        //checks distance between platform and point
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //increases index
          
          //if the platform is on the point
          if(i== points.Length)
          {
              i=0; //resets index
          }

        }


        // moving position of the platform to the position of index i
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);//when player colides with the platform it sets it as the parent allowing player to stay on it
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       collision.transform.SetParent(null); // after leaving platform it sets parent back to null
    }




}
