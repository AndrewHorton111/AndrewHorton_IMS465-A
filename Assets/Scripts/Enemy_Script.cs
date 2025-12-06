using System.Collections;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public GameObject triggerArea;
    public GameObject neutralSprite;
    public GameObject fireSprite;
    public GameObject iceSprite;
    public LayerMask CheckLayers;
    public float launchForce = 10f;
    public bool frozen = false;
    public bool burned = false;
    public bool right = true;
    public AudioClip enemyPanic;

    private Rigidbody rb;
    private bool canBurn = true;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (triggerArea == null)
        {
            Debug.Log("ERROR in Enemy_Script at Start");
        }
        rb = GetComponent<Rigidbody>();
        if (rb == null )
        {
            Debug.Log("ERROR in Enemy_Script");
        }
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Runs 60 times a second.
    private void FixedUpdate()
    {
        if (burned && rb.velocity.y >= -0.1)
        {
            RaycastHit hit;
            if (right)
            {
                rb.velocity = Vector3.right * 5 + (Vector3.down * Physics.gravity.y * -1);
                Debug.DrawRay(transform.position + Vector3.right * 1.1f, Vector3.down, Color.red, 5f);
                if (Physics.Raycast(transform.position + Vector3.right * 1.1f, Vector3.down, out hit, 1.75f, CheckLayers))
                {
                    //Debug.Log("Hit: " + hit.collider.name);
                    if (hit.collider.gameObject.layer != 6 && hit.collider.gameObject.layer != 10)
                    {
                        right = false;
                    }
                }
            }
            else
            {
                rb.velocity = Vector3.left * 5 + (Vector3.down * Physics.gravity.y * -1);
                Debug.DrawRay(transform.position + Vector3.left * 1.1f, Vector3.down, Color.red, 5f);
                if (Physics.Raycast(transform.position + Vector3.left * 1.1f, Vector3.down, out hit, 1.75f, CheckLayers))
                {
                    //Debug.Log("Hit: " + hit.collider.name);
                    if (hit.collider.gameObject.layer != 6 && hit.collider.gameObject.layer != 10)
                    {
                        right = true;
                    }
                }
            }
            if (hit.collider == null)
            {
                right = !right;
            }
        }
        else if (frozen)
        {
            rb.velocity = Vector3.zero;
        }

        if (burned)
        {
            
        }
        else if (frozen)
        {
            
        }
        else
        {
            if (neutralSprite.transform.position.y > iceSprite.transform.position.y)
            {
                if (neutralSprite.transform.position.y > fireSprite.transform.position.y)
                {
                    return;
                }
            }
            if (iceSprite.transform.position.y > fireSprite.transform.position.y)
            {
                
            }
            else
            {
                
            }
        }

        if (rb.velocity.y > (Physics.gravity.y * -1) + 1f) {
            rb.velocity = rb.velocity + (Vector3.down * Physics.gravity.y * -0.5f);
        }
        else
        {
            //Debug.Log(rb.velocity.y + " " + (Physics.gravity.y * -1) + 1f);
        }

        if (rb.velocity.x < 0)
        {
            neutralSprite.transform.localScale = new Vector3(-0.5f, 0.3333333333333333333f, 1);
            fireSprite.transform.localScale = new Vector3(-0.5f, 0.3333333333333333333f, 1);
            iceSprite.transform.localScale = new Vector3(-0.5f, 0.3333333333333333333f, 1);
        }
        else if (rb.velocity.x > 0)
        {
            neutralSprite.transform.localScale = new Vector3(0.5f, 0.3333333333333333333f, 1);
            fireSprite.transform.localScale = new Vector3(0.5f, 0.3333333333333333333f, 1);
            iceSprite.transform.localScale = new Vector3(0.5f, 0.3333333333333333333f, 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Firebolt"))
        {
            if (frozen)
            {
                frozen = false;
                neutralSprite.transform.position = iceSprite.transform.position;
                iceSprite.transform.position += Vector3.down * 100;
            }
            else
            {
                burned = true;
                //fireSprite.transform.position = neutralSprite.transform.position;
                //neutralSprite.transform.position += Vector3.down * 100;
                StartCoroutine(stopBurn());
            }

            //    //transform.position = transform.position + (Vector3.right * 10);
            //    transform.position = transform.position + (Vector3.right * 3);
            //    moved = 60;
        }
        else if (other.gameObject.CompareTag("Iceball"))
        {
            if (burned)
            {
                burned = false;
                neutralSprite.transform.position = fireSprite.transform.position;
                fireSprite.transform.position += Vector3.down * 100;
            }
            else
            {
                frozen = true;
                iceSprite.transform.position = neutralSprite.transform.position;
                neutralSprite.transform.position += Vector3.down * 100;
            }
        }
    }

    public IEnumerator stopBurn()
    {
        //Debug.Log("Stop Burn Call");
        if (canBurn)
        {
            audioSource.PlayOneShot(enemyPanic, 0.2f); ;
            canBurn = false;
            fireSprite.transform.position = neutralSprite.transform.position;
            neutralSprite.transform.position += Vector3.down * 100;
            yield return new WaitForSeconds(5f);
            burned = false;
            neutralSprite.transform.position = fireSprite.transform.position;
            fireSprite.transform.position += Vector3.down * 100;
            rb.velocity = Vector3.zero;
            canBurn = true;
            audioSource.Stop();
            //Debug.Log("Stop Burn End");
        }
    }

    // Launches objects that enter the child trigger area.
    // -1 means left and 1 means right.
    public void LaunchObject(Rigidbody otherRb, int dir)
    {
        if (frozen)
        {
            return;
        }


        if (dir == -1)
        {
            //Debug.Log("LaunchObject Left");
            otherRb.velocity = new Vector3(-launchForce, 0, 0);
        }
        else
        {
            //Debug.Log("LaunchObject Right");
            otherRb.velocity = new Vector3(launchForce, 0, 0);
        }
    }
}
