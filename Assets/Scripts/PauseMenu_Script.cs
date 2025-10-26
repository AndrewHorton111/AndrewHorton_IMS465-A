using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu_Script : MonoBehaviour
{
    public bool isShowing = false;

    private CanvasGroup canvasGroup;
    private GameObject gameManager;
    private GameManager_Script gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
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
        }

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.Log("ERROR in CanvasGroup portion of the PauseMenu_Script");
        }
        else
        {
            canvasGroup.alpha = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isShowing = !isShowing;
            swapVisibility();
        }
    }

    public void swapVisibility()
    {
        if (isShowing)
        {
            canvasGroup.alpha = 1;
            Time.timeScale = 0f;
        }
        else
        {
            canvasGroup.alpha = 0;
            Time.timeScale = 1f;
        }
    }

    public void onMainMenuButton()
    {
        if (Time.timeScale == 0f)
        {
            isShowing = false;
            canvasGroup.alpha = 0;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Start_Menu");
        }
        
    }

    public void onLevelSelectButton()
    {
        if (Time.timeScale == 0f)
        {
            isShowing = false;
            canvasGroup.alpha = 0;
            Time.timeScale = 1f;
            SceneManager.LoadScene("LevelSelect_Menu");
        }
    }

    public void onRestartButton()
    {
        if (Time.timeScale == 0f)
        {
            isShowing = false;
            canvasGroup.alpha = 0;
            Time.timeScale = 1f;
            gameManagerScript.SetPlayingFalse();
            gameManagerScript.RestartLevel();
        }
    }
}
