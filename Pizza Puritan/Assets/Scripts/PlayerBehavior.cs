using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    float speed = 9;
    float jump = 12;
    private Vector2 vel;
    float accel = 50;
    float decel = 45;
    bool grounded = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("up") && grounded)
        {
            //Debug.Log("UP");
            grounded = false;
            rb.velocity = new Vector2(0, jump);
        } else if (Input.GetKeyDown("down"))
        {
            rb.velocity = new Vector2(0, -jump * 1.2f);
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
        {
            vel.x = Mathf.MoveTowards(vel.x, speed * moveInput, accel * Time.deltaTime);
        }
        else
        {
            if (grounded)
            {
                vel.x = Mathf.MoveTowards(vel.x, 0, decel * Time.deltaTime);
            } else
            {
                vel.x = Mathf.MoveTowards(vel.x, 0, decel * 2f * Time.deltaTime);
            }
            
        }
        transform.Translate(vel * Time.deltaTime);
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            transform.position = new Vector3(0f, 0f, 0f);
            Debug.Log("DONT MIX PINEAPPLE AND PIZZA");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("OnCollisionEnter2D");
        grounded = true;

        if (col.gameObject.tag == "wall")
        {
            vel.x *= -1f;
            rb.gravityScale = 1f;
        }
        if (col.gameObject.tag == "ramp")
        {
            
            rb.gravityScale = 5f;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        //grounded = false;
        rb.gravityScale = 3;
        if (col.gameObject.tag == "ramp")
        {
            
        }
    }

    
}
