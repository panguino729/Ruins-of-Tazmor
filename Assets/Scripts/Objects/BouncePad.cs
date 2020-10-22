using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A bouncepad that will cause objects with the script "Bounceable" on them to bounce in a specified direction, or up if not specified.
/// </summary>
public class BouncePad : MonoBehaviour
{
    public List<Plate> plates; //A list of plates that can be used to enable or disable the bounce pad if all are pressed
    public bool needsPlates; //If false, ignores the plates list
    public bool platesEnable; //If true, pressing all plates enables the bounce pad. If false, pressing all plates disables the bounce pad.
    private bool platesPressed; //Are all of the plates pressed?
    public float bounceDirX;
    public float bounceDirY;
    public float bounceMag;
    private bool justPressedOrUnpressed;
    private Vector2 bounceDir;
    // Start is called before the first frame update
    void Start()
    {
        justPressedOrUnpressed = false;
        if(bounceDirX == 0 && bounceDirY == 0)
        {
            bounceDirY = 1;
        }
        if(bounceMag == 0)
        {
            bounceMag = 1000;
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
        if (needsPlates)
        {
            if(plates == null)
            {
                throw new System.Exception("Plates cannot be null if you have needsPlates enabled. " +
                    "If you don't want to switch the bouncepad on/off with plates, disable needsPlates. " +
                    "Otherwise, add plates to the list.");
            }
            for (int i = 0; i < plates.Count; i++)
            {
                if (!plates[i].pressed)
                {
                    if (platesPressed)
                    {
                        justPressedOrUnpressed = true;
                    }
                    platesPressed = false;
                    break;
                }
                if (i == plates.Count - 1)
                {
                    if (!platesPressed)
                    {
                        justPressedOrUnpressed = true;
                    }
                    platesPressed = true;
                }
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Bounces if the bouncepad: 
        //1. Does not care about plates 
        //2. Cares about plates, plates enable the pad, and all plates are pressed
        //3. Cares about plates, plates disable the pad, and not all plates are pressed
        if (!needsPlates || (platesEnable && platesPressed) || (!platesEnable && !platesPressed)) 
        {
            if (collision.gameObject.name.Contains("Bounceable")) //Upon colliding the bounce pad, apply a force to bounce the object
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(bounceMag * bounceDir);
                Debug.Log("Bounce");
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Makes it so that objects sitting on a bouncepad are bounced as soon as the plates allow it to bounce them
        if(justPressedOrUnpressed)
        {
            OnCollisionEnter2D(collision);
        }
    }
}
