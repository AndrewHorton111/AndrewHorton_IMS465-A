using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect_Script : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager_Script gameManagerScript;
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.Log("ERROR in CanvasGroup portion of the PauseMenu_Script");
        }

        gameManager = GameObject.FindWithTag("GameManager");
        if (gameManager == null)
        {
            Debug.Log("ERROR in LevelSelect");
        }
        else
        {
            gameManagerScript = gameManager.GetComponent<GameManager_Script>();
            if (gameManagerScript == null)
            {
                Debug.Log("ERROR in LevelSelect");
            }
            else
            {
                gameManagerScript.SetPlayingFalse();
                if (gameManagerScript.restart)
                {
                    gameManagerScript.restart = false;
                    canvasGroup.alpha = 0;
                    Restart(gameManagerScript.level);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void on1_1Button()
    {
        gameManagerScript.SetLevel(0);
        SceneManager.LoadScene("Level1");
    }

    public void on1_2Button()
    {
        gameManagerScript.SetLevel(1);
        SceneManager.LoadScene("Level1");
    }

    public void on1_3Button()
    {
        gameManagerScript.SetLevel(2);
        SceneManager.LoadScene("Level1");
    }

    public void on2_1Button()
    {
        gameManagerScript.SetLevel(2);
        SceneManager.LoadScene("Level1");
    }

    public void on2_2Button()
    {
        gameManagerScript.SetLevel(2);
        SceneManager.LoadScene("Level1");
    }

    public void on2_3Button()
    {
        gameManagerScript.SetLevel(2);
        SceneManager.LoadScene("Level1");
    }

    public void onHomeButton()
    {
        SceneManager.LoadScene("Start_Menu");
    }

    public void Restart(int level)
    {
        if (level == 0)
        {
            on1_1Button();
        }
        else if (level == 1)
        {
            on1_2Button();
        }
        else if (level == 2)
        {
            on1_3Button();
        }
        else if (level == 3)
        {
            on2_1Button();
        }
        else if (level == 4)
        {
            on2_2Button();
        }
        else if (level == 5)
        {
            on2_3Button();
        }
        else
        {
            Debug.Log("ERROR in LevelSelect_Script regarding the Restart method");
        }
    }
}
