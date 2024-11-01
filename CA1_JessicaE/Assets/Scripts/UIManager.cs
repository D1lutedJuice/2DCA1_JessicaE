using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    
   [SerializeField] TMP_Text FishText;
    [SerializeField] private Image[] Images;

    [SerializeField] private GameObject tryAgainButton;


    public static UIManager instance;

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

    public void RestartGame()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(0);
    }
}
