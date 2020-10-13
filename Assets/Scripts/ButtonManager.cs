using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject uIManager;
    
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
        SceneManager.LoadScene("TestScene");
    }
    
    public void OnChangeSpell()
    {
        Debug.Log("Change Spells");
    }
    
    public void OnMenu()
    {
        uIManager.GetComponent<UIManager>().ButtonPress("pause)");
    }
}
