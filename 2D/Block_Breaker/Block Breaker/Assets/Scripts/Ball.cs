using UnityEngine;

public class Ball : MonoBehaviour
{
    #region parameters

    [SerializeField] Paddle paddle1;
    [SerializeField] float xLaunch = 2f;
    [SerializeField] float yLaunch = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = .5f;

    #endregion

    #region state

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    #endregion

    #region cached component reference

    AudioSource myAudioSource;

    Rigidbody2D myRigidBody2D;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallMouseClick();
        }
    }

    private void LaunchBallMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xLaunch, yLaunch);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
