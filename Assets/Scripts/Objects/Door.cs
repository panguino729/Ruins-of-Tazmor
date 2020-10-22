using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

/// <summary>
/// A door that is opened when all plates are pressed.
/// </summary>
public class Door : MonoBehaviour
{
    public float currRotation = 0;
    public bool isYRotation; //If true, changes y rotation. If false, x rotation.
    public float rotationDegrees;
    public bool reappears; //Determines whether or not the door reappears when the plates are no longer pressed
    public List<Plate> plates;
    public bool open = false;
    BoxCollider2D bCollider;
    SpriteRenderer spRender;    

    // Start is called before the first frame update
    void Start()
    {
        if (rotationDegrees == 0)
        {
            rotationDegrees = 2.5f;
        }
        bCollider = GetComponent<BoxCollider2D>();
        spRender = GetComponent<SpriteRenderer>();
        if (name == null)
        {
            name = "Door";
        }
        else
        {
            name += "Door";
        }
    }

    // Update is called once per frame
    void Update()
    {
        open = true;
        for (int i = 0; i < plates.Count; i++)
        {
            if (!plates[i].pressed)
            {
                open = false;
                break;
            }
        }
        if (open)
        {
            if(isYRotation && currRotation < 90)
            {
                transform.Rotate(new Vector3(rotationDegrees, 0, 0));
                currRotation += rotationDegrees;
            }
            else if(!isYRotation && currRotation < 90)
            {
                transform.Rotate(new Vector3(0, rotationDegrees, 0));
                currRotation += rotationDegrees;
            }
            if (!reappears)
            {
                Destroy(gameObject);
            }
            bCollider.isTrigger = true;
        }
        else
        {
            if (isYRotation && currRotation > 0)
            {
                transform.Rotate(new Vector3(-rotationDegrees, 0, 0));
                currRotation -= rotationDegrees;
            }
            else if (!isYRotation && currRotation > 0)
            {
                transform.Rotate(new Vector3(0, -rotationDegrees, 0));
                currRotation -= rotationDegrees;
            }
            bCollider.isTrigger = false;
        }
    }
}
