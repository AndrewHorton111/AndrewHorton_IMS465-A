using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Script : MonoBehaviour
{
    public GameObject iceBlock;
    
    //private bool frozen = false;
    private float waterForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            //Debug.Log("Check #1");
            if (other.gameObject.CompareTag("Iceball"))
            {
                //Debug.Log("Check #2");
                //frozen = true;
                iceBlock.transform.position = transform.position;
                transform.position = Vector3.down * 1000;
                other.transform.position = Vector3.down * 10000;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * waterForce); 
        }
    }
}
