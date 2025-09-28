using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Script : MonoBehaviour
{
    public GameObject fan;
    private Fan_Script fanScript;

    // Start is called before the first frame update
    void Start()
    {
        fanScript = fan.GetComponent<Fan_Script>();
        if (fanScript == null)
        {
            Debug.LogError("ERROR: No script found in button code.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        fanScript.switchFan();
    }
}
