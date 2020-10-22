using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public Scene nextLevel;
    public List<Scene> levels;
    private int currentLevel;


    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
