using UnityEngine;

public class Block : MonoBehaviour
{
    //Config
    [Header("Graphics and Sound")]
    [SerializeField] private AudioClip breakSound = null;
    [SerializeField] private GameObject blockSparklesVFX = null;
    [SerializeField] private Sprite[] hitSprites;
    
    //Cached References
    private Level _level;
    private GameStatus _gameStatus;
    
    //State Variables
    [Header("For debugging purposes")]
    [SerializeField] private int timesHit;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        _level = FindObjectOfType<Level>();
        if (CompareTag("Breakable"))
        {
            _level.CountBlocks();
        }
        _gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
       
    }
    
     private void ShowNextHitSprite()
     {
         int spriteIndex = timesHit - 1;
         if (hitSprites[spriteIndex] != null)
         {
             GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
         }
         else
         {
             Debug.LogError("Block sprite is missing from array" + gameObject.name);
             
         }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
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
