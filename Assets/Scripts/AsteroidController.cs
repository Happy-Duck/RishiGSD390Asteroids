using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidController : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidPrefab;

    [SerializeField]
    public static float asteroidSpeed = 100;

    [SerializeField]
    private Sprite sprite1;
    [SerializeField]
    private Sprite sprite2;
    [SerializeField]
    private Sprite sprite3;
    [SerializeField]
    private Sprite sprite4;

    [SerializeField]
    private AudioClip destroySound;

    private int splitDepth;

    public static int score = 0;

    private void Awake()
    {
        int AsteroidSpriteNum = Random.Range(1, 4);

        if (AsteroidSpriteNum == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        } else if (AsteroidSpriteNum == 2)
        {
            gameObject.gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        } else if (AsteroidSpriteNum == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite4;
        }

        Color randomColor = Color.white;
        randomColor.r = Random.Range(0.5f, 1);
        randomColor.g = Random.Range(0.5f, 1);
        randomColor.b = Random.Range(0.5f, 1);

        gameObject.GetComponent<SpriteRenderer>().color = randomColor;
    }

    public void Split()
    {
        var newAsteroid1 = Instantiate(asteroidPrefab);
        var newAsteroid2 = Instantiate(asteroidPrefab);

        newAsteroid1.transform.position = transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        newAsteroid1.transform.position = transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));

        newAsteroid1.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere * asteroidSpeed);
        newAsteroid2.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere * asteroidSpeed);

        newAsteroid1.GetComponent<AsteroidController>().setSize(splitDepth + 1);
        newAsteroid2.GetComponent<AsteroidController>().setSize(splitDepth + 1);


        Destroy(gameObject);
    }

    public void setSize(int splitDepth)
    {
        this.splitDepth = splitDepth;

        if (splitDepth ==  0)
        {
            transform.localScale = Vector3.one;

        } else if (splitDepth == 1)
        {
            transform.localScale = Vector3.one * 0.66f;

        } else if (splitDepth == 2)
        {
            transform.localScale = Vector3.one * 0.33f;

        } else
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullets"))
        {
            Debug.Log("Asteroid hit by bullet!");
            AudioSource.PlayClipAtPoint(destroySound, new Vector3(0, 0, -10));
            Split();
            score+= 1;
            Debug.Log(score);
            
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            SceneManager.LoadScene(2);
        }


        Destroy(gameObject);

    }
}
