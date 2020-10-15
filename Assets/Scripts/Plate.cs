using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Object
{
    public bool pressed = false;
    public Material blueMat;
    public Material redMat;
    public SpriteRenderer renderer;
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
            renderer.material = redMat;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Moveable") || collision.gameObject.name.Contains("Player"))
        {
            pressed = false;
            renderer.material = blueMat;
        }
    }
}
