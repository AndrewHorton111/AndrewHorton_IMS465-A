using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect_Script : MonoBehaviour
{
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
}
