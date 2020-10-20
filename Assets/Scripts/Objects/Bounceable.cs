using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounceable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (name == null)
        {
            name = "Bounceable";
        }
        else
        {
            name += "Bounceable";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
