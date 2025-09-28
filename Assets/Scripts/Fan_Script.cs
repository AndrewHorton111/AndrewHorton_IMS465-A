using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Fan_Script : MonoBehaviour
{
    public int direction;
    public LayerMask StopsFanLayers;

    private float pushForce = 1f;
    private bool turnedOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called 60 times a second.
    private void FixedUpdate()
    {
        
    }

    public void switchFan()
    {
        turnedOn = !turnedOn;
    }

    public void OnObjectStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (turnedOn && rb != null )
        {
            RaycastHit hit;
            float length = (other.transform.position - transform.position).magnitude;
            if (Physics.Raycast(transform.position, other.transform.position - transform.position, out hit, length, StopsFanLayers))
            {
                //collider.transform.position = Vector3.up*10f;
            }
            else
            {
                Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.red, 10f);
                // Direction is right
                if (direction == 1) {
                    rb.AddForce(Vector3.right * pushForce, ForceMode.Impulse);
                }
                // Direction is down
                if (direction == 2)
                {
                    rb.AddForce(Vector3.down * pushForce, ForceMode.Impulse);
                }
                // Direction is left
                if (direction == 3)
                {
                    rb.AddForce(Vector3.left * pushForce, ForceMode.Impulse);
                }
                // Direction is up
                else
                {
                    rb.AddForce(Vector3.up * pushForce, ForceMode.Impulse);
                }
            }
            
        }
    }
}
