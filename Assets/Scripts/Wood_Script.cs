using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Wood_Script : MonoBehaviour
{
    public bool burned;
    public GameObject neutral;
    public GameObject fire;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = neutral.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    transform.position = Vector3.down * 4000;
        //}
    }

    private void FixedUpdate()
    {
        if (burned && transform.position.y > -9000000)
        {
            fire.transform.position = startPos;
            neutral.transform.position = Vector3.down * 100;
        }
        else if (!burned && transform.position.y > -9000000)
        {
            neutral.transform.position = startPos;
            fire.transform.position = Vector3.down * 100;
        }
    }

    public void OnBurn()
    {
        burned = true;
        StartCoroutine(Burn());
    }

    private IEnumerator Burn()
    {
        yield return new WaitForSeconds(5f);
        if (burned)
        {
            transform.position = Vector3.down * 10000000;
        }
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
