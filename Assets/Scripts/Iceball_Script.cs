using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceball_Script : MonoBehaviour
{
    public GameObject player;
    public AudioClip iceBallFreezeSound;

    private Rigidbody iceballRb;
    private Rigidbody playerRb;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        iceballRb = GetComponent<Rigidbody>();
        playerRb = player.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
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
        Debug.Log("Collision: " + other.name);
        if (other.gameObject.CompareTag("Firebolt"))
        {
            Debug.Log("Iceball collided with Firebolt");
            Rigidbody otherRb = other.GetComponent<Rigidbody>();
            otherRb.velocity = Vector3.zero;
            other.transform.position = Vector3.down * 1000f;

            iceballRb.velocity = Vector3.zero;
            transform.position = Vector3.down * 1000f;
            transform.position += Vector3.left * 100000f;
        }
        else if (other.gameObject.CompareTag("Fan"))
        {
            Fan_Script fan = other.GetComponent<Fan_Script>();
            if (fan.burned) {
                fan.burned = false;
            }
            else
            {
                fan.frozen = true;
            }
            transform.position = Vector3.down * 1000f;
            transform.position += Vector3.left * 100000f;
        }
        else if (other.gameObject.CompareTag("Wood"))
        {
            Wood_Script wood = other.GetComponent<Wood_Script>();
            wood.burned = false;
            iceballRb.velocity = Vector3.zero;
            transform.position = Vector3.down * 10000;
            transform.position += Vector3.left * 100000f;
        }
        else
        {
            if (!other.gameObject.CompareTag("Player") && other.gameObject.layer != 1)
            {
                iceballRb.velocity = Vector3.zero;
                transform.position = Vector3.down * 20000f;
                transform.position += Vector3.left * 100000f;
                audioSource.PlayOneShot(iceBallFreezeSound, 0.4f);
            }
            return;
        }
        audioSource.PlayOneShot(iceBallFreezeSound, 0.4f);
    }
}
