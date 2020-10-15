using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Object
{
    public bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
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

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains("Moveable") || collision.gameObject.name.Contains("Player"))
        {
            pressed = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Moveable") || collision.gameObject.name.Contains("Player"))
        {
            pressed = false;
        }
    }
}
