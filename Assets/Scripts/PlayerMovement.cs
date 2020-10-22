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
    private BoxCollider2D boxCollider2D;
    private bool jumping;
    Vector3 startPos;

    public AudioSource jump;
    public AudioSource telekinesis;

    void Start()
    {
        player = this;
        name += "Player";
        startPos = this.transform.position;
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        jumping = false;
    }

    void FixedUpdate()
    {
        ApplyForce();
    }

    void ApplyForce()
    {
        float movespeed = 5f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            float jumpV = 15f;
            rb.velocity = Vector2.up * jumpV;
            jump.Play();
        }
    }

    //
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, Physics2D.AllLayers, 0, 0);
        return raycastHit2D.collider != null;
    }

    //may be handled in collision manager later on, must be implemented
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
