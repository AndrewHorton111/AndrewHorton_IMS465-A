using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu_Script : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager_Script gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        if (gameManager == null)
        {
            Debug.Log("ERROR in StartMenu");
        }
        else
        {
            gameManagerScript = gameManager.GetComponent<GameManager_Script>();
            if (gameManagerScript == null)
            {
                Debug.Log("ERROR in StartMenu");
            }
            else if (gameManagerScript.loaded == false)
            {
                gameManagerScript.SetPlayingFalse();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onNewGameButton()
    {
        gameManagerScript.SetLevel(0);
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
