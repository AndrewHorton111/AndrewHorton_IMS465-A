using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Script : MonoBehaviour
{
    public GameObject triggerArea;
    public LayerMask CheckLayers;
    public float launchForce = 10f;
    public bool frozen = false;
    public bool burned = false;
    public bool right = true;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        if (triggerArea == null)
        {
            Debug.Log("ERROR in Enemy_Script at Start");
        }
        rb = GetComponent<Rigidbody>();
        if (rb == null )
        {
            Debug.Log("ERROR in Enemy_Script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Runs 60 times a second.
    private void FixedUpdate()
    {
        if (burned && rb.velocity.y >= -0.1)
        {
            RaycastHit hit;
            if (right)
            {
                rb.velocity = Vector3.right * 5 + (Vector3.down * Physics.gravity.y * -1);
                Debug.DrawRay(transform.position + Vector3.right * 1.1f, Vector3.down, Color.red, 5f);
                if (Physics.Raycast(transform.position + Vector3.right * 1.1f, Vector3.down, out hit, 1.75f, CheckLayers))
                {
                    //Debug.Log("Hit: " + hit.collider.name);
                    if (hit.collider.gameObject.layer != 6 && hit.collider.gameObject.layer != 10)
                    {
                        right = false;
                    }
                }
            }
            else
            {
                rb.velocity = Vector3.left * 5 + (Vector3.down * Physics.gravity.y * -1);
                Debug.DrawRay(transform.position + Vector3.left * 1.1f, Vector3.down, Color.red, 5f);
                if (Physics.Raycast(transform.position + Vector3.left * 1.1f, Vector3.down, out hit, 1.75f, CheckLayers))
                {
                    //Debug.Log("Hit: " + hit.collider.name);
                    if (hit.collider.gameObject.layer != 6 && hit.collider.gameObject.layer != 10)
                    {
                        right = true;
                    }
                }
            }
            if (hit.collider == null)
            {
                right = !right;
            }
        }
        else if (frozen)
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Firebolt"))
        {
            if (frozen)
            {
                frozen = false;
            }
            else
            {
                burned = true;
                StartCoroutine(stopBurn());
            }

            //    //transform.position = transform.position + (Vector3.right * 10);
            //    transform.position = transform.position + (Vector3.right * 3);
            //    moved = 60;
        }
        else if (other.gameObject.CompareTag("Iceball"))
        {
            if (burned)
            {
                burned = false;
            }
            else
            {
                frozen = true;
            }
        }
    }

    public IEnumerator stopBurn()
    {
        Debug.Log("Check #1");
        yield return new WaitForSeconds(5f);
        burned = false;
        rb.velocity = Vector3.zero;
    }

    // Launches objects that enter the child trigger area.
    // -1 means left and 1 means right.
    public void LaunchObject(Rigidbody otherRb, int dir)
    {
        if (frozen)
        {
            return;
        }


        if (dir == -1)
        {
            //Debug.Log("LaunchObject Left");
            otherRb.velocity = new Vector3(-launchForce, 0, 0);
        }
        else
        {
            //Debug.Log("LaunchObject Right");
            otherRb.velocity = new Vector3(launchForce, 0, 0);
        }
    }
}
