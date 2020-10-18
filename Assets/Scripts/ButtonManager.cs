using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject uI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void OnSettings()
	{
		Debug.Log("Clicked Settings");
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
}