using UnityEngine;
using TMPro;
public class LoseCollider : MonoBehaviour
{
    // trying to add multiple lives
    [Header("Adjust Lives")]
    [SerializeField] private int numberOfLives = 3;
    [SerializeField] private TextMeshProUGUI livesText;
    //Got red error when using below line
    //public Ball _ball = FindObjectOfType<Ball>();

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        numberOfLives--;
        livesText.text = numberOfLives.ToString();
        if (numberOfLives <= 0)
        {
            FindObjectOfType<SceneLoader>().GameOver();
        }

        else
        {
            //Put ball back on paddle and stick
            FindObjectOfType<Ball>().hasStarted = false;
          
            
        }
    }


}