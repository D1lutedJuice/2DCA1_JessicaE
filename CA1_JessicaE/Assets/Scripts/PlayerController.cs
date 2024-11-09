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
         private int victoryCondition= 15;//15 fish to collect
         private int totalFish= 0;
         public float groundCheckRadius;
         public Transform groundCheck;
         public bool groundDetected;
         public LayerMask whatIsGround;
         private bool isFacingRight;

         Vector2 startPos;

         AudioManager audioManager; //set the audiomanager so we can call from it

        
         

    // Start is called before the first frame update
    void Start()
    {
        //initialise components
       _animator = GetComponent<Animator>();
       _rigidbody= GetComponent<Rigidbody2D>();
       audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
       totalFish = GameObject.FindGameObjectsWithTag("Fish").Length;

       startPos = transform.position; //setting the start pos
       
       UIManager.Instance.setFishCollected(0, totalFish);//calls method setfishcollected and 0 & totalFish as the parameters
           
       isFacingRight= true;// on start player faces right

    }

    // Update is called once per frame
    void Update()
    {
        CollisionCheck(); //calls this method so we are constantly checking for collision

        float moveby= Input.GetAxis("Horizontal");//gets horizontal input 
         
         //changed the movement to velocity because my player kept sticking to walls so changing this helped me fix it because i can now use physics materials
         //this helped me get the idea of velocity movement https://connorgamedev.medium.com/day-108-player-movement-for-a-2d-platformer-a6bfa4fd5839
         //updates horizontal movement while leaving vertical movememnt unchanged allowing for jump to work
         _rigidbody.velocity = new Vector2(moveby * speed, _rigidbody.velocity.y);
          
         if(moveby !=  0) //if movement is not equal to 0
        {
            _animator.SetBool("isRunning", true); //sets the is running bool to true allowing animation to play
        }
        else
        {
            _animator.SetBool("isRunning", false); //otherwise set it to false so it doesnt play
        }

         //used this video for help with double jump https://www.youtube.com/watch?v=2akPDnmSfu8
        if(groundDetected && Input.GetKeyDown(KeyCode.Space) )//if theres ground detected and player uses space key
        {
           jump();//calls jump method 
             doubleJump=false;//sets doublejump as false meaning player has not used double jump
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !groundDetected )//otherwise if theres no ground detected and player has not used double jump
        {
           
           jump();
           doubleJump=true;//sets double jump as true meaning player used their double jump 
          
        }

        if(!isFacingRight && moveby > 0)//if player is moving and is not facing right
        {
            Flip();//calls flip method to flip the sprite
        }else if(isFacingRight && moveby < 0)
        {
            Flip();
        }

        
    }

    public void jump()
    {
        // used this video for the jump animation https://www.youtube.com/watch?v=ux80fiJshsc
         _animator.SetBool("isJumping", !groundDetected);//sets bool that player is jumping to the bool of the opposite of grounddetected
       _rigidbody.velocity= new Vector2(_rigidbody.velocity.x, JumpHeight);//keeps x the same and sets y to jumpheight
       audioManager.PlaySFX(audioManager.jump);//calls playSFX method from audioManager to play the jump sound each time player jumps
    }

    //used this video for help https://www.youtube.com/watch?v=ux80fiJshsc
    public void Flip()
    {
        isFacingRight= !isFacingRight;//sets the bool to the oposite of what it currently is
        Vector3 localScale= transform.localScale;//gets the current scale
        localScale.x *= -1f;//invert x axis to flip, multiplying by -1  so it doesnt move position
        transform.localScale=localScale;//apply new scale to flip
    }

    

     //used this video to make basic collision check https://www.youtube.com/watch?v=7hDCL9tNdKc&list=PLPa3cUXF8edKq7r_ty_nAtDuD0_QXB_Kz&index=9
    private void CollisionCheck()
    {
        //checks if the character is on the ground if there are overlaps with ground layer
        groundDetected = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        _animator.SetBool("isJumping", !groundDetected);//sets bool that player is jumping to if theres no ground detected
    }
   
    public void Die() {
        audioManager.PlaySFX(audioManager.death);//calls method to play the death sound effect
        UIManager.Instance.OpenEndScreen();//calls method using instance in UIManager to open the end screen.
        
    }



     public void AddFish()
    {
        audioManager.PlaySFX(audioManager.collect);//calls method to play the collect sound effect
        fishCollected++;//for each fish collected adds +1
        Debug.Log(fishCollected);
        UIManager.Instance.setFishCollected(fishCollected, totalFish);//calls the setFishCollected method and adds the fishcollected, and totalfish to it.

    }


      //used this video for help with finish https://www.youtube.com/watch?v=BlK9-U3Rwx8&list=PL986L3_21ogBR4_Bm5KGh_XdT-aOxSSt6&index=5
    public void Finish()
    {
        if(fishCollected >= victoryCondition)//if the fishcollected is greater or equal to the ammount needed to win
        {
             UIManager.Instance.OpenWinScreen();//calls the winScreen method in UIManager
             audioManager.PlaySFX(audioManager.gameWin);//calls method to play the win sound effect
        }
        else // otherwise if it doesnt meet the condition
        { 
             UIManager.Instance.ShowVictoryCondition();//calls method to showVictoryCondition
             audioManager.PlaySFX(audioManager.victoryCondition);//calls method to play the victory condition sound effect
        }
    }

    
     //used this video for help https://www.youtube.com/watch?v=7hDCL9tNdKc&list=PLPa3cUXF8edKq7r_ty_nAtDuD0_QXB_Kz&index=8
     private void OnDrawGizmos()
     {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);//draws a sphere that helps see the ground check area during editing
     }
    
}
