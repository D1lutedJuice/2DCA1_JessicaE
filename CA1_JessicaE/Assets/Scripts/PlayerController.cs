using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
     //variables
         [SerializeField] private float speed;
         [SerializeField] private int direction=1;
         [SerializeField] private float JumpHeight;

         private Animator _animator;
         private Rigidbody2D _rigidbody;
         private bool isJumping= false;
         private int JumpCount= 0;


    // Start is called before the first frame update
    void Start()
    {
        //initialise component
       _animator = GetComponent<Animator>();
       _rigidbody= GetComponent<Rigidbody2D>();

        _animator.SetFloat("Move X",0);
        _animator.SetFloat("Move Y",1);

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

        if(JumpCount< 2 && Input.GetKeyDown(KeyCode.Space))
       {
        isJumping=true;
         Debug.Log("Jump");
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(new Vector2(0, Mathf.Sqrt(-2*Physics2D.gravity.y * JumpHeight)), ForceMode2D.Impulse);
        JumpCount++;

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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isJumping)
        {
            isJumping=false;
            JumpCount=0;
        }
    }
}
