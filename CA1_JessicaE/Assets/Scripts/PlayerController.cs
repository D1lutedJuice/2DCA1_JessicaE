using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
     //variables
         [SerializeField] private float speed;
         [SerializeField] private int direction=0;

         private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        //initialise component
       _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //used code from our platformer game example
        //basic movement - gets horizontal input and updates pos x based on speed
        float moveby= Input.GetAxis("Horizontal");
        Vector2 position= transform.position;
        position.x += speed * moveby * Time.deltaTime;
        transform.position= position;

         if(moveby !=  0)
        {
            direction = moveby < 0 ? -1 : 1;
        }

        //calls method that plays animation
        playAnimation (moveby);
    }


     private void playAnimation(float moveby)
    {
        if(moveby ==0)
        {
            _animator.SetFloat("Move X",0);
        }
        else if (moveby <0)
        {
            _animator.SetFloat("Move X",-1);
            _animator.SetFloat("Move Y",-1);
        }
        else
        {
            _animator.SetFloat("Move X",1);
            _animator.SetFloat("Move Y",1);
        }
    }
}
