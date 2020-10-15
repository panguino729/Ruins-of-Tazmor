using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Object
{
    public Scene levelComplete;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.name == "Player")
            {
                //SceneManager.SetActiveScene(levelComplete);
                SceneManager.LoadScene("LevelComplete");
            }
       }
}
