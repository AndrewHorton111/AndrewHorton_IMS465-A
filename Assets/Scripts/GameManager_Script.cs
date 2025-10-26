using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Script : MonoBehaviour
{
    public int level;
    public bool restart = false;

    private GameObject player;
    private Player_Script playerScript;
    private bool gamePlaying = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePlaying && SceneManager.GetActiveScene().name == "Level1")
        {
            gamePlaying = true;
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                Debug.Log("ERROR in GameManager");
            }
            else
            {
                playerScript = player.GetComponent<Player_Script>();
                if (playerScript == null)
                {
                    Debug.Log("ERROR in GameManager");
                }
                else
                {
                    playerScript.level = level;
                    Debug.Log("Player Level: " + playerScript.level);
                    playerScript.ChangeLevel(level);
                }
            }
        }
    }

    public void RestartLevel()
    {
        restart = true;
        SceneManager.LoadScene("LevelSelect_Menu");
    }

    public void SetPlayingFalse()
    {
        gamePlaying = false;
    }

    public void SetLevel(int levelNum)
    {
        level = levelNum;
    }
}
