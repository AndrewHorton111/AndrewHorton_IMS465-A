using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Breakable_Script : MonoBehaviour
{
    public AudioClip wallBreaking;

    private float maxSpeedThreshold = 15f;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
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
            //Debug.Log(rb.velocity.magnitude);
            //Debug.Log(collision.relativeVelocity.magnitude);
            if (collision.relativeVelocity.magnitude > maxSpeedThreshold)
            {
                if (collision.relativeVelocity.x > 0)
                {
                    rb.velocity = new Vector3(-1, 0, 0);
                }
                else
                {
                    rb.velocity = new Vector3(1, 0, 0);
                }
                BreakObject();
            }
        }
    }

    public void BreakObject()
    {
        transform.position = Vector3.down * 1000000f;
        audioSource.PlayOneShot(wallBreaking, 1f);
    }
}
