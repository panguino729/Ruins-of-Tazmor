using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement player;
    private Rigidbody2D rb;

    private int jumpingCounter = 3;

    private bool jumping;
    Vector3 startPos;
    public float maxSpeed = 1.0f;
    public float jumpingForceMultiplier = 1.0f;
    public float appliedForce = 1.0f;
    public float jumpForce = 1.0f;

    void Start()
    {
        player = this;
        name = "Player";
        startPos = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
    }

    void FixedUpdate()
    {
        ApplyForce();
    }

    void ApplyForce()
    {
        Vector2 uForce = new Vector2();

        uForce += GetKeyDirection() * appliedForce;

        //apply jumping impulse
        if(GetJump())
            uForce += new Vector2(0.0f, jumpForce);

        //reduce horizontal force when jumping
        if (jumping)
            uForce.x *= jumpingForceMultiplier;
        
        rb.AddForce(uForce);

        //cap speed
        float speed = math.abs(rb.velocity.x);
        if (speed > maxSpeed)
            rb.velocity = new Vector2(speed / rb.velocity.x * maxSpeed , rb.velocity.y);
    }

    /// <summary>
    /// get the direction of movement based on WASD or arrow keys
    /// </summary>
    Vector2 GetKeyDirection()
    {
        Vector2 direction = new Vector2();

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x += 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x -= 1;
        }

        return direction;
    }

    /// <summary>
    /// did the player just hit jump?
    /// set jumping to appropriate value
    /// </summary>
    bool GetJump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumping == false)
            {
                jumping = true;
                return true;
            }
        }
        
        if(rb.velocity.y == 0)
        {
            if (jumpingCounter != 0)
            {
                jumpingCounter -= 1;
            }
            else
            {
                jumping = false;
                jumpingCounter = 3;
            } 
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "victory":
                //Occurs when the player reaches the end of the level
                break;
            default:
                break;
        }
    }
}
