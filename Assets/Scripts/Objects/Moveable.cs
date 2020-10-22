using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes the object moveable by telekinesis
/// </summary>
public class Moveable : MonoBehaviour
{
    public float moveStrength; //The strength of the force that telekinesis applies - could potentially make this different on different objects.
    public float maxVelocity; //The maximum velocity during telekinesis.
    private Rigidbody2D rb;
    public LineRenderer line;
    private bool isBeingHeld = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 8;
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
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y < 0.001)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if ((rb.velocity.x != 0 || rb.velocity.y != 0) && isBeingHeld) //Only triggers if the object is moving, to limit the calls per frame
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
            // Do a linecast to check if this object is in line of sight of the player
            // EVERYTHING that has a collider and should not be checked against (boxes, the player, whatever else)
            // should be on a layer OTHER THAN LAYER 0!
            LayerMask losMask = LayerMask.GetMask("Default");
            Vector3 playerPos = PlayerMovement.player.gameObject.transform.position;
            RaycastHit2D lineOfSight = Physics2D.Linecast(playerPos, transform.position, losMask);
            

            if (lineOfSight.collider != null)
            {
                Debug.DrawLine(playerPos, lineOfSight.point, Color.red);
                line.SetPositions(new Vector3[]{ playerPos, lineOfSight.point});
                line.startColor = line.endColor = Color.red;
                
                rb.gravityScale = 1;
            }
            else // If there's no collider in the way, do what we'd normally do for telekinesis
            {
                Debug.DrawLine(PlayerMovement.player.gameObject.transform.position, transform.position, Color.blue);
                line.SetPositions(new Vector3[] { playerPos, transform.position });
                line.startColor = line.endColor = Color.blue;

                rb.gravityScale = 0;

                Vector3 mousePos = Input.mousePosition;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                isBeingHeld = true;
                Vector3 vtoc = mousePos - this.transform.position;
                float distToMouseSqr = vtoc.x * vtoc.x + vtoc.y * vtoc.y;
                rb.AddForce(moveStrength * distToMouseSqr * (mousePos - this.transform.position));
            }

            line.material.SetTextureScale("_MainTex", new Vector2(1, 1));
        }
    }
    private void OnMouseDown() //Checks if the player left clicks on a moveable object in order to apply telekinesis
    {
        if (Input.GetMouseButtonDown(0))
        {
            line.enabled = true;
            rb.gravityScale = 0;
            isBeingHeld = true;
        }
    }
    private void OnMouseUp() //If the player releases the mouse, no longer applies telekinesis
    {
        line.enabled = false;
        rb.gravityScale = 1;
        isBeingHeld = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains("Player"))
        {
            line.enabled = false;
            rb.gravityScale = 1;
            isBeingHeld = false;
        }
    }
}
