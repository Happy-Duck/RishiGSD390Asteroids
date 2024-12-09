using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
          Destroy(gameObject);
    }

    private void Awake()
    {
        Destroy(gameObject, 0.75f); //bullet seppukus after 0.75 seconds
    }
}
