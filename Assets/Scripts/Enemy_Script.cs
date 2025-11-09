using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public GameObject triggerArea;
    public float launchForce = 10f;

    private int moved = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (triggerArea == null)
        {
            Debug.Log("ERROR in Enemy_Script at Start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Runs 60 times a second.
    private void FixedUpdate()
    {
        if (moved > 0)
        {
            moved--;
            if (moved == 0)
            {
                transform.position = transform.position - (Vector3.right * 3);
            } 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Firebolt")) {
            //transform.position = transform.position + (Vector3.right * 10);
            transform.position = transform.position + (Vector3.right * 3);
            moved = 60;
        }
    }

    // Launches objects that enter the child trigger area.
    // -1 means left and 1 means right.
    public void LaunchObject(Rigidbody otherRb, int dir)
    {
        if (dir == -1)
        {
            Debug.Log("LaunchObject Left");
            otherRb.velocity = new Vector3(-launchForce, 0, 0);
        }
        else
        {
            //Debug.Log("LaunchObject Right");
            otherRb.velocity = new Vector3(launchForce, 0, 0);
        }
    }
}
