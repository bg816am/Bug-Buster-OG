using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config Params
    [SerializeField] private Paddle paddleOne = null;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds = null;
    [SerializeField] private float randomFactor = 0.2f;
    
    //State
    private Vector2 _paddleToBallVector;
    
    //Cached component references
    //Allows for avoidance of using GetComponent<ComponentName>():
    private AudioSource _myAudioSource;
    private Rigidbody2D _myRigidbody2D;
    private bool _hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        _paddleToBallVector = transform.position - paddleOne.transform.position;
        _myAudioSource = GetComponent<AudioSource>();
        _myRigidbody2D = GetComponent<Rigidbody2D>();
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
            _myRigidbody2D.velocity = new Vector2(xPush, yPush);
            _hasStarted = true;
        }
    }

    public void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddleOne.transform.position.x, paddleOne.transform.position.y);
        transform.position = paddlePos + _paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (_hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            _myAudioSource.PlayOneShot(clip);
            _myRigidbody2D.velocity += velocityTweak;
        }
    }
}

