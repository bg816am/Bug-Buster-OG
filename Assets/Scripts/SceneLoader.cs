using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void StartGame()
   {
       SceneManager.LoadScene(0);
       FindObjectOfType<GameStatus>().ResetGame();
   }

   public void LoadNextScene()
   {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentSceneIndex + 1);
   }

   public void ExitGame()
   {
       Application.Quit();
   }

   public void GameOver()
   {
       int lastScene = SceneManager.sceneCountInBuildSettings - 1;
       SceneManager.LoadScene(lastScene);
   }
}
