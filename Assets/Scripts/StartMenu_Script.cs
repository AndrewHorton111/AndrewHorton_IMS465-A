using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onNewGameButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void onLevelSelectButton()
    {
        SceneManager.LoadScene("LevelSelect_Menu");
    }

    public void OnCreditsButton()
    {

    }

    public void OnQuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
