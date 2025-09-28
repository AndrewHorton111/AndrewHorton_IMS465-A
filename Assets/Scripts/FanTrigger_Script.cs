using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTrigger_Script : MonoBehaviour
{
    private Fan_Script parentScript;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<Fan_Script>();
        if (parentScript == null)
        {
            Debug.LogError("ERROR: No parent script in fan trigger area.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (parentScript != null)
        {
            parentScript.OnObjectStay(other);
        }
    }
}
