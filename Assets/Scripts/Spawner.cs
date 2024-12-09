using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject asteroid;

    float timer = 2;

    [SerializeField]
    private GameObject player;

    // Update is called once per frame  
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            var newAsteroid = Instantiate(asteroid);

            int side = Random.Range(0, 3);

            if (side == 0)
            {
                newAsteroid.transform.position = new Vector3(-8, Random.Range(-4, 4), 0);
            } else if (side == 1)
            {
                newAsteroid.transform.position = new Vector3(8, Random.Range(-4, 4), 0);
            }
            else if (side == 2)
            {
                newAsteroid.transform.position = new Vector3(Random.Range(-8, 8), 7, 0);
            } else if (side == 3)
            {
                newAsteroid.transform.position = new Vector3(Random.Range(-8, 8), -7, 0);
            }

            newAsteroid.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere * AsteroidController.asteroidSpeed);
            timer = Random.Range(1, 3);
        }
    }
}
