using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Script : MonoBehaviour
{
    public GameObject player;
    public GameObject ExplosionSprite;
    public LayerMask explodableLayers;
    public LayerMask StopsExplosionLayers;
    public AudioClip bombExplosionSound;

    private float ExplosionForce = 10f;

    private Rigidbody bombRb;
    private Rigidbody playerRb;

    private bool explosionStarted = false;
    private bool frozen = false;
    private bool burned = false;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Runs 60 times a second.
    private void FixedUpdate()
    {
        if (explosionStarted == false && transform.position.y > -50 && frozen == false)
        {
            explosionStarted = true;
            StartCoroutine(ExplosionTimer(3));
        }
    }

    // Starts an explosion 5 seconds after the bomb is created, unless frozen.
    private IEnumerator ExplosionTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Explosion();
    }

    // Explodes the bomb when detonated
    private void Explosion()
    {
        if ((frozen && !burned) || transform.position.y < -50) {
            return;
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3, explodableLayers);
        foreach (Collider collider in hitColliders)
        {
            // Makes sure there is no object between the bomb and the target object.
            RaycastHit hit;
            float length = (collider.transform.position - transform.position).magnitude;
            Debug.DrawRay(transform.position, collider.transform.position-transform.position, Color.red, 10f);
            if (Physics.Raycast(transform.position, collider.transform.position-transform.position, out hit, length, StopsExplosionLayers))
            {
                //collider.transform.position = Vector3.up*10f;
            } 
            // Blows up breakable walls and floors.
            else if (collider.gameObject.layer == 9 || collider.gameObject.layer == 10)
            {
                Debug.Log("Break hit");
                Debug.DrawRay(transform.position, collider.transform.position - transform.position, Color.green, 10f);
                Breakable_Script breakableScript = collider.gameObject.GetComponent<Breakable_Script>();
                if (breakableScript != null)
                {
                    breakableScript.BreakObject();
                }
            }
            else
            {
                Rigidbody objectRb = collider.GetComponent<Rigidbody>();
                if (objectRb != null)
                {
                    objectRb.AddForce((collider.transform.position - transform.position).normalized * ExplosionForce, ForceMode.Impulse);
                    Debug.DrawRay(transform.position, collider.transform.position - transform.position, Color.green, 10f);
                }
            }
            audioSource.PlayOneShot(bombExplosionSound, 0.04f);
        }
        ExplosionSprite.transform.position = transform.position;
        ExplosionSprite.transform.position += Vector3.down * 2f;
        frozen = false;
        burned = false;
        explosionStarted = false;
        transform.position = Vector3.down * 100000f;
        StartCoroutine(MoveExplosionSprite());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Firebolt")) {
            burned = true;
            Debug.Log("Firebolt collided with Bomb");
            Explosion();
            Rigidbody otherRb = other.GetComponent<Rigidbody>();
            otherRb.velocity = Vector3.zero;
            other.transform.position = Vector3.down * 1000f;
        }
        else if (other.gameObject.CompareTag("Iceball"))
        {
            Debug.Log("Iceball collided with Bomb");
            frozen = true;
        }
    }

    // Sets the sprite of the explosion when the explosive explodes.
    private IEnumerator MoveExplosionSprite()
    {
        yield return new WaitForSeconds(1);
        ExplosionSprite.transform.position += Vector3.one * 10000;
    }
}
