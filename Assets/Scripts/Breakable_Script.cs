using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Breakable_Script : MonoBehaviour
{
    private float maxSpeedThreshold = 15f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision");
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null )
        {
            Debug.Log(rb.velocity.magnitude);
            if (rb.velocity.magnitude > maxSpeedThreshold)
            {
                BreakObject();
            }
        }
    }

    public void BreakObject()
    {
        transform.position = Vector3.down * 1000000f;
    }
}
