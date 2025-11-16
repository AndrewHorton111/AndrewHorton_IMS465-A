using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTrigger_Script : MonoBehaviour
{
    private Wood_Script parentScript;
    private bool burned = false;
    private bool alreadyBurned = false;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<Wood_Script>();
        if (parentScript == null)
        {
            Debug.LogError("ERROR in WoodTrigger_Script at Start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        burned = parentScript.burned;
        if (!burned)
        {
            alreadyBurned = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(burned);
        if (burned)
        {
            Debug.Log("Check #2");
            Enemy_Script enemy = other.GetComponent<Enemy_Script>();
            if (enemy != null)
            {
                Debug.Log("Check #3");
                if (enemy.frozen)
                {
                    enemy.frozen = false;
                    alreadyBurned = true;
                }
                else if (!alreadyBurned)
                {
                    Debug.Log("AlreadyBurned Status: " + alreadyBurned);
                    enemy.burned = true;
                    StartCoroutine(enemy.stopBurn());
                }
            }
            else
            {
                Debug.Log("ERROR in WoodTrigger_Script at onTriggerStay");
            }
        }
    }
}
