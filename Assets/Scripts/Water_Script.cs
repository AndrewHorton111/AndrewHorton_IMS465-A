using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Script : MonoBehaviour
{
    private float waterForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
