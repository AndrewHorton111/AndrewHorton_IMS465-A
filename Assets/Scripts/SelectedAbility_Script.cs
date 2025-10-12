using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedAbility_Script : MonoBehaviour
{
    public Sprite firebolt;
    public Sprite iceball;
    public Sprite bomb;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChnageSprite(int newAbility)
    {
        Debug.Log("Check #1");
        if (image == null)
        {
            return;
        }

        Debug.Log("Check #2");
        if (newAbility == 1)
        {
            image.sprite = firebolt;
        }
        else if (newAbility == 2)
        {
            image.sprite = iceball;
            Debug.Log("Check #3");
        }
        else if (newAbility == 3)
        {
            image.sprite = bomb;
        }
        else
        {
            Debug.Log("ERROR in SelectedAbility Script");
        }
    }
}
