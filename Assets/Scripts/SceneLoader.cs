using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadStartMenu() 
   {
       SceneManager.LoadScene(0);
   }

   public void StartGame()
   {
       SceneManager.LoadScene(1);
   }

   public void ExitGame()
   {
       Application.Quit();
   }
}
