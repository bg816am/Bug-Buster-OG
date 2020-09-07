using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound = null;
    [SerializeField] private GameObject blockSparklesVFX = null;
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
        PlayBreakSound();
        RemoveBlock();
        TriggerSparklesVFX();
    }

    private void RemoveBlock()
    {
        Destroy(gameObject);
        _level.BlockDestroyed();
    }

    private void PlayBreakSound()
    {
        _gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1.0f);
    }
}
