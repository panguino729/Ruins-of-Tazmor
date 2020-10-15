using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuState
{
    Game,
    Pause,
    Settings,
    Spells
}

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private GameObject[] pauseObjects;
    [SerializeField] private GameObject[] settingsObjects;
    [SerializeField] private GameObject[] spellsObjects;
    
    public MenuState currentMenuState = MenuState.Game;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
        pauseObjects = GameObject.FindGameObjectsWithTag("showOnPause");
        //settingsObjects = GameObject.FindGameObjectsWithTag("showOnSettings");
        //spellsObjects = GameObject.FindGameObjectsWithTag("showOnSpells");
        
        HideMenu(pauseObjects);
        HideMenu(settingsObjects);
        HideMenu(spellsObjects);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentMenuState)
        {
            case MenuState.Game:
                // If ESC is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MenuControl(pauseObjects, MenuState.Pause);
                }
                break;
            case MenuState.Pause:
                // If ESC is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MenuControl(pauseObjects, MenuState.Game);
                }
                break;
                //If somehow not the Game state, menu state or inventory state, assume it is menu and can go back to game state
            default:
                // If ESC is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MenuControl(pauseObjects, MenuState.Game);
                }
                break;
        }   
    }
    
    //---------METHODS---------

    /// <summary>
    /// Toggles the selected menu on or off
    /// </summary>
    /// <param name="menuObjects">Menu items to toggle</param>
    /// <param name="menuState">Which menu is going to be toggled</param>
    public void MenuControl(GameObject[] menuObjects, MenuState menuState)
    {
        // If paused, show UI elements labeled ShowOnPause
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            currentMenuState = menuState;
            ShowMenu(menuObjects);
        }
        // Unpausing game hides UI elements labeled ShowOnPause
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            currentMenuState = MenuState.Game;
            HideMenu(menuObjects);
        }
    }

    /// <summary>
    /// Shows the objects in the menu
    /// </summary>
    /// <param name="menuObjects">Menu items to show</param>
    public void ShowMenu(GameObject[] menuObjects)
    {
        // Set all of the UI elements active
        foreach (GameObject g in menuObjects)
        {
            g.SetActive(true);
        }
    }

    /// <summary>
    /// Hides the objects in the menu
    /// </summary>
    /// <param name="menuObjects"Menu items to hide</param>
    public void HideMenu(GameObject[] menuObjects)
    {
        // Set all of the UI elements active
        foreach (GameObject g in menuObjects)
        {
            g.SetActive(false);
        }
    }
    
    /// <summary>
    /// Checks which button was pressed
    /// <summary>
    /// <aparm name="name"Name of button pressed</param>
    public void ButtonPress(string name)
    {
        if (name == "pause")
        {
            Debug.Log("click Pause");
            MenuControl(pauseObjects, MenuState.Pause);
        }
        else if (name == "spell")
        {
            MenuControl(spellsObjects, MenuState.Spells);
        }
    }
}