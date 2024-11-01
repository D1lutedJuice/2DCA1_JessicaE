using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    
   [SerializeField] TMP_Text FishText;
    [SerializeField] private Image[] Images;

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

    
}
