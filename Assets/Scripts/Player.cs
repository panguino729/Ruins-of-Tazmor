using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(tag)
        {
            case "trap":
                this.transform.position = startPos; //There'll need to be a ResetLevel() method later - I'm just doing this as a placeholder.
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "victory":
                //Occurs when the player reaches the end of the level
                break;
            default:
                break;
        }
    }
}
