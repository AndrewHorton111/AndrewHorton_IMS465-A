using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Fan_Script : MonoBehaviour
{
    public bool burned = false;
    public bool frozen = false;
    public int direction;
    public LayerMask StopsFanLayers;
    public bool turnedOn = false;

    public GameObject neutral;
    public GameObject ice;
    public GameObject fire;

    private float initialPushForce = 0.25f;
    private float pushForce = 0;
    private Vector3 spritePos;
    //private DynamicFanSprite_Script fanSpriteScript;

    // Start is called before the first frame update
    void Start()
    {
        //fanSpriteScript = GetComponentInChildren<DynamicFanSprite_Script>();
        //if (fanSpriteScript == null)
        //{
        //    Debug.Log("ERROR in Fan_Script");
        //}
        //Debug.Log("Check 1 - " + turnedOn);
        if (neutral == null || ice == null || fire == null)
        {
            Debug.Log("ERROR in Fan_Script");
        }
        spritePos = neutral.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called 60 times a second.
    private void FixedUpdate()
    {
        //Debug.Log("Check 2 - " + this.name + " - " + turnedOn);
        if (burned == true)
        {
            pushForce = initialPushForce * 2f;
            fire.transform.position = spritePos;
            ice.transform.position = Vector3.down * 500;
            neutral.transform.position = Vector3.down * 500;

        }
        else if (frozen == true)
        {
            pushForce = 0f;
            ice.transform.position = spritePos;
            neutral.transform.position = Vector3.down * 500;
            fire.transform.position = Vector3.down * 500;
        }
        else
        {
            pushForce = initialPushForce;
            neutral.transform.position = spritePos;
            ice.transform.position = Vector3.down * 500;
            fire.transform.position = Vector3.down * 500;
        }
    }

    public void switchFan()
    {
        //Debug.Log("Switch");
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
                else if (direction == 2)
                {
                    rb.AddForce(Vector3.down * pushForce, ForceMode.Impulse);
                }
                // Direction is left
                else if (direction == 3)
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
