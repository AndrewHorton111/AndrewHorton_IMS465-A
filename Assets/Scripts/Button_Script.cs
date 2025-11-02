using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Script : MonoBehaviour
{
    public GameObject OnState;
    public GameObject OffState;
    public GameObject fan;

    private Fan_Script fanScript;
    private bool isFanOn = false;

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

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CHECK");
        fanScript.switchFan();
        if (isFanOn)
        {
            OffState.transform.position = OnState.transform.position;
            OnState.transform.position = Vector3.down * 1000;
        }
        else
        {
            OnState.transform.position = OffState.transform.position;
            OffState.transform.position = Vector3.down * 1000;
        }
        isFanOn = !isFanOn;
    }
}
