using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

/// <summary>
/// A door that is opened when all plates are pressed.
/// </summary>
public class Door : MonoBehaviour
{
    public bool rotatesAboutX; //If true, rotations about X axis (i.e. up and down). False = about y axis.
    public int rotationDegrees;
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
            rotationDegrees = 10;
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
            if (rotatesAboutX && transform.rotation.y < 180)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + rotationDegrees, transform.rotation.z);
            }
            else if (!rotatesAboutX && transform.rotation.x < 180)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x + rotationDegrees, transform.rotation.y, transform.rotation.z);
            }
            if (!reappears && transform.rotation.y >= 180)
            {
                Destroy(gameObject);
            }
            bCollider.isTrigger = true;
        }
        else
        {
            if (rotatesAboutX && transform.rotation.y > 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - rotationDegrees, transform.rotation.z);
            }
            else if (!rotatesAboutX && transform.rotation.x > 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x - rotationDegrees, transform.rotation.y, transform.rotation.z);
            }
            bCollider.isTrigger = false;
        }
    }
}
