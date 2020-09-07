using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;
    private SceneLoader _sceneLoader;

    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            _sceneLoader.LoadNextScene();
        }
    }
    
    
}
