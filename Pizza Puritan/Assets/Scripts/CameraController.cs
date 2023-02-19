using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float screen = 18f;
    float screenHeight = 10f;
    public GameObject player;
    private float posX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        posX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > transform.position.x + (screen / 2))
        {
            transform.Translate(screen, 0, 0);
        } else if (player.transform.position.x < transform.position.x - (screen / 2))
        {
            transform.Translate(-screen, 0, 0);
        }

        if (player.transform.position.y > transform.position.y + (screenHeight / 2))
        {
            transform.Translate(0, screenHeight, 0);
        }
        else if (player.transform.position.y < transform.position.y - (screenHeight / 2))
        {
            transform.Translate(0, -screenHeight, 0);
        }
    }
}
