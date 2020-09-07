using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound = null;

    //Cached References
    private Level _level;
    private GameStatus _gameStatus;

    private void Start()
    { 
         _level = FindObjectOfType<Level>();
        _level.CountBreakableBlocks();
        _gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        _gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        _level.BlockDestroyed();
    }
}
