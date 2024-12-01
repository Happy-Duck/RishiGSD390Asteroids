using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    [SerializeField]
    private TextMesh endText;

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

        if (AsteroidController.score < PlayerMover.winScore)
        {
            endText.text = "You Lost";
        }
        else
        {
            endText.text = "You Won!";
        }
    }
}
