using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Object
{
    // Start is called before the first frame update
    void Start()
    {
        if(name == null)
        {
            name = "Trap";
        }
        else
        {
            name += "Trap";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
