using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    //Variables
    [SerializeField] TMP_Text FishText;
    [SerializeField] private TMP_Text Countdown;
    [SerializeField] private Image[] Images;
    [SerializeField] private GameObject tryAgainButton;
     [SerializeField] private GameObject winRestartButton;
    [SerializeField] GameObject victoryCondition;
    private static UIManager instance;

     //setting instance so we can access UIManager in other scripts easier 
    public void Start()
    {
        instance = this;
    }
    public static UIManager Instance
    {
        get{
            return instance;
        }
    }

    public void setFishCollected(int numCollected, int total)//takes parameters of the number collected and total
    {
        FishText.text = numCollected.ToString() + "/"+total.ToString();//sets the text to display the number collected over the total 
    }

    // used this video for help https://www.youtube.com/watch?v=Y-Zt_hxtcUc
    public void OpenEndScreen()
    {
        Time.timeScale = 0;//pauses the game
        tryAgainButton.SetActive(true);//sets the button to active so it appears on screen
    }

    public void OpenWinScreen()
    {
        Time.timeScale = 0;//pauses the game
        winRestartButton.SetActive(true);//sets the button to active so it appears on screen
        
    }

    public void RestartGame()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(1);//restarts the scene 1
    }

    public void ShowVictoryCondition()
    {
        victoryCondition.SetActive(true);//sets the victory condition to active so it appears on screen
    }

     public void HideVictoryCondition()
    {
        victoryCondition.SetActive(false);//sets victory condition as false so the condition dissapears 
    }


    public void ShowCountdown(float currentTime)
    {
         Countdown.text= currentTime.ToString("0");//sets time based on the currentTime
         
    }

}
