using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject uI;

    private List<string> levels;
    private static int levelIndex = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        levels = new List<string>();
        levels.Add("Level_01");
        levels.Add("Level_02");
        levels.Add("Level_03");
        levels.Add("Level_04");
        levels.Add("Level_05");
        levels.Add("Level_06");
        levels.Add("Level_07");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoreNext()
    {
        Debug.Log("Clicked Lore Next");
        uI.GetComponent<UIManager>().LoreControl();
    }

    public void OnBackToTitle()
    {
        Debug.Log("Clicked Back to Title Screen");
        SceneManager.LoadScene("TitleScene");
    }
    
    public void OnStart()
    {
        SceneManager.LoadScene("Level_01");
    }
    
    public void OnPause()
    {
        Debug.Log("Clicked Pause");
		uI.GetComponent<UIManager>().ButtonPress("pause");
    }

    public void OnResume()
	{
		Debug.Log("Clicked Resume");
		uI.GetComponent<UIManager>().ButtonPress("resume");
	}

    public void OnRestartLevel()
	{
		Debug.Log("Clicked Restart Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void OnQuit()
	{
		Debug.Log("Clicked Quit");
		SceneManager.LoadScene("TitleScene");
	}

    public void OnSpells()
    {
        Debug.Log("Clicked Spells");
        uI.GetComponent<UIManager>().ButtonPress("spell");
    }

    public void OnCloseSpells()
    {
        Debug.Log("Clicked Close Spells");
        uI.GetComponent<UIManager>().ButtonPress("spellClose");
    }

    public void OnNext()
    {
        Debug.Log("Clicked Next Level");
        Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(levelIndex);
        levelIndex++;
    }
}