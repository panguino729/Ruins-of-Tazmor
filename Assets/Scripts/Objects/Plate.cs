using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A plate that is pressed when a player or moveable object interacts with it
/// </summary>
public class Plate : Object
{
    public bool pressed = false;
    private int numPresses = 0;
    private float initialYScale;
    private BoxCollider2D collider;
    private float initialHeight;
    int framesSincePressed = 0;
    public float indentHeight; //The % height that the plate changes each frame upon being pressed - should probably be about 0.1
    GameObject collided;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        if(indentHeight == 0)
        {
            indentHeight = 0.025f;
        }
        initialYScale = transform.localScale.y;
        collider = GetComponent<BoxCollider2D>();
        initialHeight = collider.bounds.size.y;
        if (name == null)
        {
            name = "Plate";
        }
        else
        {
            name += "Plate";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numPresses > 0 && transform.localScale.y > 0.5f * initialYScale)
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - indentHeight * initialYScale, transform.localScale.z);
            gameObject.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - indentHeight * initialHeight, transform.localPosition.z);
            collided.gameObject.transform.localPosition = new Vector3(collided.gameObject.transform.localPosition.x, collided.gameObject.transform.localPosition.y - indentHeight * initialHeight, collided.gameObject.transform.localPosition.z);
        }
        else if(numPresses <= 0 && transform.localScale.y < 1.0f * initialYScale && framesSincePressed > 5)
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + indentHeight * initialYScale, transform.localScale.z);
            gameObject.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + indentHeight * initialHeight, transform.localPosition.z);
        }
        if(numPresses == 0)
        {
            framesSincePressed++;
        }
        if (transform.localScale.y <= 0.5f * initialYScale && !pressed)
        {
            pressed = true;
            source.Play();
        }
        else if (transform.localScale.y >= 1.0f * initialYScale)
        {
            pressed = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains("Moveable") || collision.gameObject.name.Contains("Player"))
        {
            collided = collision.gameObject;
            numPresses++;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Moveable") || collision.gameObject.name.Contains("Player"))
        {
            numPresses--;
            if (numPresses == 0)
            { 
                framesSincePressed = 0;
            }
        }
    }
}
