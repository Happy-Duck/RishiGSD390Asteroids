using UnityEngine;
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
    public static int winScore = 20;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed = 10;

    [SerializeField]
    public TextMesh scoreText;

    private Rigidbody2D rigidbody = new Rigidbody2D();

    void Awake()
    {
        AsteroidController.score = 0;
        rigidbody = GetComponent<Rigidbody2D>();
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
        }

        if (AsteroidController.score >= winScore)
        {
            SceneManager.LoadScene(2);
        }

    }
}
