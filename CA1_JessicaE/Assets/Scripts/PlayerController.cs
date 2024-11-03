using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
     //variables
         [SerializeField] private float speed;
    
         [SerializeField] private float JumpHeight;
         [SerializeField] private int fishCollected=0;

         private Animator _animator;
         private Rigidbody2D _rigidbody;
        
         private bool doubleJump;
         private int victoryCondition= 16;
         private int totalFish= 0;

         public float groundCheckRadius;
         public Transform groundCheck;
         public bool groundDetected;
         public LayerMask whatIsGround;
         private bool isFacingRight;

         Vector2 startPos;

         AudioManager audioManager;

        
         

    // Start is called before the first frame update
    void Start()
    {
        //initialise component
       _animator = GetComponent<Animator>();
       _rigidbody= GetComponent<Rigidbody2D>();
       startPos = transform.position; //setting the start pos
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        totalFish = GameObject.FindGameObjectsWithTag("Fish").Length;
        UIManager.Instance.setFishCollected(0, totalFish);
           
        isFacingRight= true;

    }

    // Update is called once per frame
    void Update()
    {
        CollisionCheck();
        //used code from our platformer game example
        //basic movement - gets horizontal input and updates pos x based on speed
        float moveby= Input.GetAxis("Horizontal");
         
         //changed the movement to velocity because my player kept sticking to walls so changing this helped me fix it because i can now use physics materials
         //this helped me get the idea of velocity movement https://connorgamedev.medium.com/day-108-player-movement-for-a-2d-platformer-a6bfa4fd5839
         //updates horizontal movement while leaving vertical movememnt unchanged allowing for jump to work
         
            _rigidbody.velocity = new Vector2(moveby * speed, _rigidbody.velocity.y);
          

         if(moveby !=  0)
        {
            _animator.SetBool("isRunning", true);
        }
        else{
            _animator.SetBool("isRunning", false);
        }

         //used this video for help with double jump https://www.youtube.com/watch?v=2akPDnmSfu8
        
          

        if(groundDetected && Input.GetKeyDown(KeyCode.Space) )
        {
           
           jump();
             doubleJump=false;
             
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !groundDetected )
        {
           
           jump();
           doubleJump=true;
          
        }

        if(!isFacingRight && moveby > 0)
        {
            Flip();
        }else if(isFacingRight && moveby < 0)
        {
            Flip();
        }

        
    }

    public void jump()
    {
        // used this video for the animation https://www.youtube.com/watch?v=ux80fiJshsc
         _animator.SetBool("isJumping", !groundDetected);
       _rigidbody.velocity= new Vector2(_rigidbody.velocity.x, JumpHeight);
       audioManager.PlaySFX(audioManager.jump);
    }

    //used this video for help https://www.youtube.com/watch?v=ux80fiJshsc
    public void Flip()
    {
        isFacingRight= !isFacingRight;
        Vector3 localScale= transform.localScale;
        localScale.x *= -1f;
        transform.localScale=localScale;
    }

    


    private void CollisionCheck()
    {

        groundDetected = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        _animator.SetBool("isJumping", !groundDetected);
    }
   
    public void Die() {

        audioManager.PlaySFX(audioManager.death);
        UIManager.Instance.OpenEndScreen();
        
    }



     public void AddFish()
    {
        audioManager.PlaySFX(audioManager.collect);
        fishCollected++;
        Debug.Log(fishCollected);
         UIManager.Instance.setFishCollected(fishCollected, totalFish);

    }


      //used this video for help https://www.youtube.com/watch?v=BlK9-U3Rwx8&list=PL986L3_21ogBR4_Bm5KGh_XdT-aOxSSt6&index=5
    public void Finish()
    {
        if(fishCollected >= victoryCondition)
        {
             UIManager.Instance.OpenWinScreen();
             audioManager.PlaySFX(audioManager.gameWin);
        }
        else
        { 
             UIManager.Instance.ShowVictoryCondition();
              audioManager.PlaySFX(audioManager.victoryCondition);
        
        }
    }

    
     //used this video for help https://www.youtube.com/watch?v=7hDCL9tNdKc&list=PLPa3cUXF8edKq7r_ty_nAtDuD0_QXB_Kz&index=8
     private void OnDrawGizmos()
     {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
     }
    
}
