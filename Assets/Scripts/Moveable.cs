using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float moveStrength; //The strength of the force that telekinesis applies - could potentially make this different on different objects.
    public float maxVelocity; //The maximum velocity during telekinesis.
    public Rigidbody2D rb;
    private bool isBeingHeld = false;
    // Start is called before the first frame update
    void Start()
    {
        if(moveStrength == 0)
        {
            moveStrength = 2;
        }
        if(maxVelocity == 0)
        {
            maxVelocity = 3;
        }
        if(name == null)
        {
            name = "Moveable";
        }
        else
        {
            name += "Moveable";
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y < 0.001)
        {
            rb.velocity = new Vector2(0, 0);
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
    }
    private void OnMouseDown() //Checks if the player left clicks on a moveable object in order to apply telekinesis
    {
        if (Input.GetMouseButtonDown(0))
        {

            rb.gravityScale = 0;
            isBeingHeld = true;
        }
    }
    private void OnMouseUp() //If the player releases the mouse, no longer applies telekinesis
    {

        rb.gravityScale = 1;
        isBeingHeld = false;
    }
}
