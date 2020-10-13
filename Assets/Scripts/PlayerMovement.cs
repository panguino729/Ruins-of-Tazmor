using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool jumping;
    Vector3 startPos;
    public float maxSpeed = 1.0f;
    public float jumpingForceMultiplier = 1.0f;
    public float appliedForce = 1.0f;
    public float jumpForce = 1.0f;

    void Start()
    {
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
            jumping = false;
        }

        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "trap":
                this.transform.position = startPos; //There'll need to be a ResetLevel() method later - I'm just doing this as a placeholder.
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "victory":
                //Occurs when the player reaches the end of the level
                break;
            default:
                break;
        }
    }
}
