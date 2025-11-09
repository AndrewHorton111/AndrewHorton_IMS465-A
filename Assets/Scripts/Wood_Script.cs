using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    transform.position = Vector3.down * 4000;
        //}
    }

    public void OnBurn()
    {
        StartCoroutine(Burn());
    }

    private IEnumerator Burn()
    {
        yield return new WaitForSeconds(1f);
        transform.position = Vector3.down * 4000;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //Debug.Log(collision.gameObject.tag);
    //    if (collision.gameObject.CompareTag("Firebolt"))
    //    {
    //        transform.position = Vector3.down * 4000;
    //    }  
    //}
}
