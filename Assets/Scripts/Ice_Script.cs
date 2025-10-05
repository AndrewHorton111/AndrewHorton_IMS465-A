using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Script : MonoBehaviour
{
    public GameObject waterBlock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Melt()
    {
        Debug.Log("Iceblock Hit");
        //waterBlock.frozen = false;
        waterBlock.transform.position = transform.position;
        transform.position = Vector3.down * 1000;
    }
}
