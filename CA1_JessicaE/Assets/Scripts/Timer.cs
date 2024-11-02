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
    float startingTime=30f;

    float powerUpTime= 15f;
    

    // Start is called before the first frame update
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
        
        currentTime -= 1 * Time.deltaTime;
        UIManager.Instance.ShowCountdown(currentTime);

       if(currentTime<0)
         {
            currentTime= 0;
            UIManager.Instance.OpenEndScreen();
         }

        
    }

    public void AddPowerUpTime()
    {
        currentTime += powerUpTime;
    }
}
