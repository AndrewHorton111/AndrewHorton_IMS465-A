using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits_Script : MonoBehaviour
{
    //private GameObject gameManager;
    //private GameManager_Script gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.FindWithTag("GameManager");
        //if (gameManager == null)
        //{
        //    Debug.Log("ERROR in Credits");
        //}
        //else
        //{
        //    gameManagerScript = gameManager.GetComponent<GameManager_Script>();
        //    if (gameManagerScript == null)
        //    {
        //        Debug.Log("ERROR in Credits");
        //    }
        //    else if (gameManagerScript.loaded == false)
        //    {
        //        gameManagerScript.SetPlayingFalse();
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onHomeButton()
    {
        Debug.Log("Home clicked");
        SceneManager.LoadScene("Start_Menu");
    }

}
