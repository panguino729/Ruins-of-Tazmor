using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public static List<Object> objects; //An easily accessible list of all the objects

    public PlayerMovement player;
    /* 
     * objTag determines what the object can do.
     * 
     * 'moveable' - can be moved with telekinesis
     * 'trap' - teleports the player back to their starting location (placeholder)
     * 'victory' - the goal of the level
     */
    public string objTag;

    public float moveStrength; //The strength of the force that telekinesis applies - could potentially make this different on different objects.
    public float maxVelocity; //The maximum velocity during telekinesis.
    private bool isBeingHeld = false;
    public Rigidbody2D rb;
    /*//Enum to store possible properties of objects
    // 0 - None
    // 1 - Dangerous
    // 2 - Moveable
    // 3 - Moveable and Dangerous
    // 4 - Reflects
    // 5 - Reflects and Dangerous
    // 6 - Reflects and Moveable
    // 7 - Reflects, Dangerous, and Moveable
    // 8 - Pipe
    // 9 - Pipe and Dangerous
    // 10 - Pipe and Moveable
    // 11 - Pipe, dangerous, and moveable
    // 12 - Pipe and Reflects
    // 13 - Pipe, Reflects, and Dangerous
    // 14 - Pipe, Reflects, and Moveable
    // 15 - Pipe, Reflects, Dangerous, and Moveable
    // 16 - 16
    public enum ObjectProperties : short
    {
        None = 0,
        Dangerous = 1, //Kills the player
        Moveable = 2, //Can be moved with telekinesis
        Reflects = 4, //Reflects lasers
        Pipe = 8 //Connecting pipes puzzle - Van's idea
    }
    public int properties;
    private ObjectProperties objProperties;
    */
    public bool isGoal; //Determines whether or not the object is the end goal of the level
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tag = objTag;
        if (objects == null)
        {
            objects = new List<Object>();
        }
        objects.Add(this);
        //objProperties = (ObjectProperties)properties;
    }

    // Update is called once per frame
    void Update() //Probably need stuff here for pipes
    {
        if(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y < 0.001)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (isBeingHeld) 
            //Handles the telekinesis - applies a force toward the mouse cursor on the object. 
            //May need to add something to make sure multiple things can't be held at once if they slightly overlap.
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            isBeingHeld = true;
            Vector3 vtoc = mousePos - this.transform.position;
            float distToMouseSqr = vtoc.x * vtoc.x + vtoc.y * vtoc.y;
            rb.AddForce(moveStrength * distToMouseSqr * (mousePos - this.transform.position));
        }
        if (rb.velocity.x != 0 || rb.velocity.y != 0) //Only triggers if the object is moving, to limit the calls per frame
        {
            float velocityMag = rb.velocity.magnitude;
            if (velocityMag >= maxVelocity) //If the object is moving faster than its maximum velocity, applies a force in the opposite direction of that velocity to slow it down.
            {
                Vector3 velocityNorm = rb.velocity.normalized;
                rb.velocity = velocityNorm * maxVelocity;
                /*Vector3 forceDir = -velocityNorm;
                float forceMag = velocityMag - maxVelocity;
                rb.AddForce(forceDir * forceMag);*/
            }
        }
    }
    private void OnMouseDown() //Checks if the player left clicks on a moveable object in order to apply telekinesis
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (tag == "moveable")
            {
                rb.gravityScale = 0;
                isBeingHeld = true;
            }
        }
    }
    private void OnMouseUp() //If the player releases the mouse, no longer applies telekinesis
    {
        rb.gravityScale = 1;
        isBeingHeld = false;
    }
}
