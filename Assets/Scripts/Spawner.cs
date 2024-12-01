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
            newAsteroid.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
            if (Vector3.Distance(newAsteroid.transform.position, player.transform.position) < 1)
            {
                Destroy(newAsteroid);
            }
            {

            }
            newAsteroid.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere * AsteroidController.asteroidSpeed);
            timer = Random.Range(1, 3);
        }
    }
}
