using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    
   [SerializeField] TMP_Text FishText;
    [SerializeField] private TMP_Text Countdown;
    
    [SerializeField] private Image[] Images;

    [SerializeField] private GameObject tryAgainButton;
     [SerializeField] private GameObject winRestartButton;
    [SerializeField] GameObject victoryCondition;


    private static UIManager instance;

    private UIManager()
    {

    }

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

    public void setFishCollected(int numCollected, int total)
    {
        FishText.text = numCollected.ToString() + "/"+total.ToString();
    }

    // used this video for help https://www.youtube.com/watch?v=Y-Zt_hxtcUc
    public void OpenEndScreen()
    {
        Time.timeScale = 0;
        tryAgainButton.SetActive(true);
    }

    public void OpenWinScreen()
    {
        Time.timeScale = 0;
        winRestartButton.SetActive(true);
        
    }

    public void RestartGame()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(0);
    }

    public void ShowVictoryCondition()
    {
        victoryCondition.SetActive(true);
    }

     public void HideVictoryCondition()
    {
        victoryCondition.SetActive(false);
    }


    public void ShowCountdown(float currentTime)
    {
         Countdown.text= currentTime.ToString("0");
         
    }

}
