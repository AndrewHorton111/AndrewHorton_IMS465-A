using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt_Script : MonoBehaviour
{
    private Rigidbody fireboltRb;

    // Start is called before the first frame update
    void Start()
    {
        fireboltRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (other.gameObject.CompareTag("Ice"))
        {
            Ice_Script ice = other.GetComponent<Ice_Script>();
            ice.Melt();
            transform.position = Vector3.down * 10000;
        }
        else if (other.gameObject.CompareTag("Fan"))
        {
            Fan_Script fan = other.GetComponent<Fan_Script>();
            if (fan.frozen)
            {
                fan.frozen = false;
            }
            else
            {
                fan.burned = true;
            }
        }
        else if (other.gameObject.CompareTag("Wood"))
        {
            Wood_Script wood = other.GetComponent<Wood_Script>();
            wood.OnBurn();
            fireboltRb.velocity = Vector3.zero;
            transform.position = Vector3.down * 10000;
        }
        else
        {
            if (!other.gameObject.CompareTag("Player") && other.gameObject.layer != 1)
            {
                fireboltRb.velocity = Vector3.zero;
                transform.position = Vector3.down * 10000;
            }
            
        }


    }
}
