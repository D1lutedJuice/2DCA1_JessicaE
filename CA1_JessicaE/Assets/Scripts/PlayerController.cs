using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
     //variables
         [SerializeField] private float speed;
         [SerializeField] private int direction=1;
         [SerializeField] private float JumpHeight;
         [SerializeField] private int moneyCollected=0;

         private Animator _animator;
         private Rigidbody2D _rigidbody;
         private bool isJumping= false;
         private int JumpCount= 0;

         private int totalMoney= 0;

         Vector2 startPos;
         


    // Start is called before the first frame update
    void Start()
    {
        //initialise component
       _animator = GetComponent<Animator>();
       _rigidbody= GetComponent<Rigidbody2D>();
       startPos = transform.position; //setting the start pos

        _animator.SetFloat("Move X",0);
        _animator.SetFloat("Move Y",1);

        totalMoney = GameObject.FindGameObjectsWithTag("Money").Length;
        UIManager.Instance.setMoneyCollected(0, totalMoney);
           

    }

    // Update is called once per frame
    void Update()
    {
        //used code from our platformer game example
        //basic movement - gets horizontal input and updates pos x based on speed
        float moveby= Input.GetAxis("Horizontal");
         
         //changed the movement to velocity because my player kept sticking to walls so changing this helped me fix it because i can now use physics materials
         //this helped me get the idea of velocity movement https://connorgamedev.medium.com/day-108-player-movement-for-a-2d-platformer-a6bfa4fd5839
         //updates horizontal movement while leaving vertical movememnt unchanged allowing for jump to work
         _rigidbody.velocity = new Vector2(moveby * speed, _rigidbody.velocity.y);

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


    // used this video  help https://www.youtube.com/watch?v=LTpvfxYOPlU
    public void Die() {
        transform.position= startPos;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isJumping)
        {
            isJumping=false;
            JumpCount=0;
        }
    }

     public void AddMoney()
    {
        moneyCollected++;
        Debug.Log(moneyCollected);
         UIManager.Instance.setMoneyCollected(moneyCollected, totalMoney);

    }
}
