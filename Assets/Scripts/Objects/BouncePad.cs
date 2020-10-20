using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A bouncepad that will cause objects with the script "Bounceable" on them to bounce in a specified direction, or up if not specified.
/// </summary>
public class BouncePad : MonoBehaviour
{
    public float bounceDirX;
    public float bounceDirY;
    public float bounceMag;
    private Vector2 bounceDir;
    // Start is called before the first frame update
    void Start()
    {
        if(bounceDirX == 0 && bounceDirY == 0)
        {
            bounceDirY = 1;
        }
        if(bounceMag == 0)
        {
            bounceMag = 5;
        }
        bounceDir = (new Vector2(bounceDirX, bounceDirY)).normalized; //Normalized direction vector
        if (name == null)
        {
            name = "Bouncepad";
        }
        else
        {
            name += "Bouncepad";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(bounceDir);
        if (collision.gameObject.name.Contains("Bounceable")) //Upon colliding the bounce pad, apply a force to bounce the object
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(bounceMag * bounceDir);
        }
    }
}
