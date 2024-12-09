using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{

    Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var camPos = cam.WorldToViewportPoint(transform.position);


        if (camPos.x < 0) //left of screen
        {
            transform.position = new Vector3(cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x, transform.position.y, transform.position.z);
        } else if (camPos.x > 1) // right of screen
        {
            transform.position = new Vector3(cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, transform.position.y, transform.position.z);
        } else if (camPos.y < 0) // below screen
        {
            transform.position = new Vector3(transform.position.x, cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y, transform.position.z);
        } else if (camPos.y > 1) //above screen
        {
            transform.position = new Vector3(transform.position.x, cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y, transform.position.z);
        }

        //if (camPos.x < 0) //left of screen
        //{
        //    transform.position = new Vector3(transform.position.x + 15, transform.position.y, transform.position.z);
        //}
        //else if (camPos.x > 1) // right of screen
        //{
        //    transform.position = new Vector3(transform.position.x - 15, transform.position.y, transform.position.z);
        //}
        //else if (camPos.y < 0) // below screen
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        //}
        //else if (camPos.y > 1) //above screen
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
        //}


    }
}
