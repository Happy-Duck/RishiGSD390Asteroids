using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float thrust = 10;

    [SerializeField]
    private float turnSpeed = 10;

    [SerializeField]
    public static int winScore = 30;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed = 10;

    [SerializeField]
    public TextMesh scoreText;

    private Rigidbody2D rigidbody = new Rigidbody2D();

    public static int lives = 3;

    [SerializeField] private GameObject life1;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject life3;

    void Awake()
    {
        AsteroidController.score = 0;
        rigidbody = GetComponent<Rigidbody2D>();
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
        lives = 3;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) {
            rigidbody.AddForce(gameObject.transform.up*thrust);
        }

        if (Input.GetKey(KeyCode.A)) {
            rigidbody.AddTorque(turnSpeed);
        }

        if (Input.GetKey(KeyCode.D)) {
            rigidbody.AddTorque(-turnSpeed);
        }
    }

    private void Update()
    {
        scoreText.text = "Score: " + AsteroidController.score;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bulletInstance = Instantiate(bullet);
            bulletInstance.transform.position = transform.position;
            var bulletRigidbody = bulletInstance.GetComponent<Rigidbody2D>();
            bulletRigidbody.linearVelocity = gameObject.transform.up * bulletSpeed;
            gameObject.GetComponent<AudioSource>().Play();
        }

        if (AsteroidController.score >= winScore)
        {
            SceneManager.LoadScene(2);
        }

        if (lives == 2)
        {
            life1.SetActive(false);
        }
        else if (lives == 1)
        {
            life2.SetActive(false);
        }
        else if (lives < 1)
        {
            SceneManager.LoadScene(2);
        }

    }
}
