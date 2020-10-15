using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A door that is opened when all plates are pressed.
/// </summary>
public class Door : MonoBehaviour
{
    public bool reappears; //Determines whether or not the door reappears when the plates are no longer pressed
    public List<Plate> plates;
    // Start is called before the first frame update
    void Start()
    {
        if(name == null)
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
        
    }
}
