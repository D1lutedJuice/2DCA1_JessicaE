using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //used this video to help https://www.youtube.com/watch?v=o0j7PdU88a4
    //variables
    private static Timer instance;
    float currentTime=0f;
    float startingTime=40f;
    float powerUpTime= 15f;
    

    // Start is called before the first frame update
    //setting instance so we can access timer in other scripts easier 
    void Start()
    {
         instance = this;
        currentTime= startingTime;
    }

     public static Timer Instance
    {
        get{

            return instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime -= 1 * Time.deltaTime;//decrease time by 1 making countdown
        UIManager.Instance.ShowCountdown(currentTime);//updates the Ui displaying current time

       if(currentTime<0)// if the time is below 0
         {
            currentTime= 0;//sets time to 0 so it wont go in the minuses
            UIManager.Instance.OpenEndScreen();//calls endscreen method 
         }
         
       if(currentTime >= 60)//if time is at 60 or greater
       {
         currentTime=60;//sets time to 60 making maximum capacity 60
       }

        
    }

    public void AddPowerUpTime()
    {
        currentTime += powerUpTime;//adds the power up time to current time when method called
    }
}
