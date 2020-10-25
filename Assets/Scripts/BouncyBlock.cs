using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// A block that bounces upward when it falls a certain distance off of the screen. 
/// 
/// NOTE: Has really high mass and bounceForce so that the player doesn't push the platforms down.
/// 
/// </summary>
public class BouncyBlock : MonoBehaviour
{
    public float outOfScreen; //Disables the block for collisions when it's below this y level
    public float heightToBounce; //The y height at which a force is applied to bounce the block upward
    public float bounceForce; //The force of the bounce to apply
    private bool hasBeenApplied; //Whether or not the bounce force has already been applied this time the block is below the screen - makes it so that it can't be applied twice
    BoxCollider2D boxCollide;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        boxCollide = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= outOfScreen)
        {
            boxCollide.isTrigger = true;
        }
        else
        {
            boxCollide.isTrigger = false;
            hasBeenApplied = false;
        }
        if(transform.position.y <= heightToBounce && !hasBeenApplied)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, bounceForce));
            hasBeenApplied = true;
        }
    }
}
