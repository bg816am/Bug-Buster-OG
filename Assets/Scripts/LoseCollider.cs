using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LoseCollider : MonoBehaviour
{
    // trying to add multiple lives
    //[SerializeField] private int numberOfLives = 3;
    //[SerializeField] private TextMeshProUGUI livesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //numberOfLives--;
        //livesText.text = numberOfLives.ToString();
        //if (numberOfLives <= 0)
        //{
            FindObjectOfType<SceneLoader>().GameOver();
       // }
        
    }
}
