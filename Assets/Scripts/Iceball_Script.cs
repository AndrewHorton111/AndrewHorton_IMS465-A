using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceball_Script : MonoBehaviour
{
    public GameObject player;

    private Rigidbody iceballRb;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        iceballRb = GetComponent<Rigidbody>();
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Runs 60 times a second.
    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("Firebolt"))
        {
            Debug.Log("Iceball collided with Firebolt");
            Rigidbody otherRb = other.GetComponent<Rigidbody>();
            otherRb.velocity = Vector3.zero;
            other.transform.position = Vector3.down * 1000f;

            iceballRb.velocity = Vector3.zero;
            transform.position = Vector3.down * 1000f;
        }
    }
}
