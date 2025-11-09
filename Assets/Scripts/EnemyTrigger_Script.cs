using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger_Script : MonoBehaviour
{
    private Enemy_Script parentScript;
    //private Transform parentObjectTransform;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<Enemy_Script>();
        if (parentScript == null)
        {
            Debug.LogError("ERROR in EnemyTrigger_Script at Start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("EnemyTrigger Hit: " + other);
        // Checks if object has a rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Sees if the trigger is on the left or right side of the enemy.
            int dir = 1;
            Transform parentPos = transform.parent;
            if (transform.position.x < parentPos.position.x)
            {
                dir = -1;
            }
            parentScript.LaunchObject(rb, dir);
        }
    }
}
