using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicFanSprite_Script : MonoBehaviour
{
    public Sprite Neutral;
    public Sprite Ice;
    public Sprite Fire;
    public Image image;

    //private Fan_Script fanScript;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        //fanScript = GetComponentInParent<Fan_Script>();
        //if (fanScript == null)
        //{
        //    Debug.Log("ERROR in DynamicFanSprite_Script");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(int state)
    {
        //Debug.Log("Check #1");
        if (image == null)
        {
            Debug.Log("BAD");
            //return;
        }

        //Debug.Log("Check #2");
        if (state == 1)
        {
            image.sprite = Neutral;
        }
        else if (state == 2)
        {
            Debug.Log("FIRE");
            image.sprite = Fire;
            //Debug.Log("Check #3");
        }
        else if (state == 3)
        {
            image.sprite = Ice;
        }
        else
        {
            Debug.Log("ERROR in DynamicFanSprite_Script");
        }
    }
}
