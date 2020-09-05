using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config Params
    [SerializeField] private Paddle paddleOne;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;
    
    //State
    private Vector2 _paddleToBallVector;
    
    //Cached component references
    private AudioSource _myAudioSource;

    private bool _hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        _paddleToBallVector = transform.position - paddleOne.transform.position;
        _myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasStarted)
        {
            LockBallToPaddle(); 
            LauchOnMouseClick();
        }

    }

    private void LauchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            _hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddleOne.transform.position.x, paddleOne.transform.position.y);
        transform.position = paddlePos + _paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            _myAudioSource.PlayOneShot(clip);
        }
    }
}

