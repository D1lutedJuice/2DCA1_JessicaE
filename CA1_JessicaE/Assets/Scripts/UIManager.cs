using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    
   [SerializeField] TMP_Text MoneyText;
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

    public void setMoneyCollected(int numCollected, int total)
    {
        MoneyText.text = numCollected.ToString() + "/"+total.ToString();
    }

    
}
