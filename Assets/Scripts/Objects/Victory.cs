using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The goal of the level.
/// </summary>
public class Victory : Object
{
    public Scene levelComplete;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        if(name == null)
        {
            name = "Victory";
        }
        else
        {
            name += "Victory";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("Player"))
        {
            //SceneManager.SetActiveScene(levelComplete);
            source.Play();
            SceneManager.LoadScene("LevelComplete");          
        }
    }
}
