using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    [SerializeField]
    private TextMesh endText;

    [SerializeField]
    AudioClip winSound;

    [SerializeField]
    AudioClip loseSound;

    [SerializeField]
    AudioClip lifeLostSound;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }

    }

    private void Start()
    {
        if (AsteroidController.score < PlayerMover.winScore)
        {
            endText.text = "You Lost";
            AudioSource.PlayClipAtPoint(loseSound, new Vector3 (0, 0, 0));
            gameObject.GetComponent<AudioSource>().PlayOneShot(lifeLostSound);
        }
        else
        {
            endText.text = "You Won!";
            gameObject.GetComponent<AudioSource>().PlayOneShot(winSound);
        }
    }
}
