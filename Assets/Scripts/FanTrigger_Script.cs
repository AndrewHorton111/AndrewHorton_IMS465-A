using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTrigger_Script : MonoBehaviour
{
    private Fan_Script parentScript;
    private bool lastState;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<Fan_Script>();
        if (parentScript == null)
        {
            Debug.LogError("ERROR: No parent script in fan trigger area.");
        }
        lastState = parentScript.turnedOn;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Debug.Log(parentScript.turnedOn + " " + lastState);
        if (parentScript.turnedOn != lastState)
        {
            if (parentScript.turnedOn)
            {
                Debug.Log("First");
                transform.position = startingPosition;
                lastState = true;
            }
            else
            {
                Debug.Log("Second");
                transform.position = Vector3.down * 1000;
                lastState = false;
            }
            Debug.Log(transform.position.y);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (parentScript != null)
        {
            parentScript.OnObjectStay(other);
        }
    }
}
