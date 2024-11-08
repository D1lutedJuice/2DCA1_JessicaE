using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 //used this tutorial to help make the menu https://www.youtube.com/watch?v=T8zYGOadkUM
  public void LoadLevel()
  {
      SceneManager.LoadScene(1);
  }
}
