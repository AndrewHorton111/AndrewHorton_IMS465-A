using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void on1_1Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void on1_2Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void on1_3Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void on2_1Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void on2_2Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void on2_3Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void onHomeButton()
    {
        SceneManager.LoadScene("Start_Menu");
    }
}
