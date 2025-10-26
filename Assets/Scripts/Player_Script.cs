using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    // Variables
    public GameObject groundObject;
    public bool isGrounded;
    public LayerMask jumpableLayers;
    public GameObject cursor;
    public GameObject firebolt;
    public GameObject iceball;
    public GameObject bomb;
    public GameObject gameManager;
    public GameObject UI_Image;
    public int level;
    public GameObject[] levelStarts;
    public GameObject[] cameraPositions;

    private float moveSpeed = 100f;
    private float maxSpeed = 5f;
    private float jumpForce = 8f;
    private Transform defaultPos;

    private float fireboltLaunchForce = 15f;
    private float iceballLaunchForce = 5f;

    private Rigidbody playerRb;
    private Rigidbody fireboltRb;
    private Rigidbody iceballRb;
    private Rigidbody bombRb;

    private bool useFirebolt = false;
    private bool useIceball = false;
    private bool useBomb = false;

    private bool fireboltCooldowned = true;
    private bool iceballCooldowned = true;
    private bool bombCooldowned = true;
    //private IEnumerator fireboltCoroutine;
    //private IEnumerator iceballCoroutine;
    //private IEnumerator bombCoroutine;

    private SelectedAbility_Script selectAbility;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        fireboltRb = firebolt.GetComponent<Rigidbody>();
        iceballRb = iceball.GetComponent<Rigidbody>();
        bombRb = bomb.GetComponent<Rigidbody>();
        //groundLayer = LayerMask.GetMask("Ground");
        defaultPos = transform;

        selectAbility = UI_Image.GetComponent<SelectedAbility_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the player jump when they hit the space key, if they are on the ground.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsGroundedCheck();
            if (isGrounded)
            {
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0, 0);
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        // Sets the firebolt as active when the user presses "1".
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetAllToolsFalse();
            useFirebolt = true;
            selectAbility.ChnageSprite(1);
        }

        // Sets the iceball as active when the user presses "2".
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetAllToolsFalse();
            useIceball = true;
            selectAbility.ChnageSprite(2);
        }

        // Sets the bomb as active when the user presses "3".
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetAllToolsFalse();
            useBomb = true;
            selectAbility.ChnageSprite(3);
        }

        // Makes the tool shoot towards the cursor, or places the bomb where the player is.
        if (Input.GetMouseButtonDown(0))
        {
            if (useFirebolt && fireboltCooldowned)
            {
                fireboltRb.velocity = Vector3.zero;
                Vector3 direction = cursor.transform.position - transform.position;
                firebolt.transform.position = transform.position + direction.normalized;
                firebolt.transform.rotation = Quaternion.LookRotation(direction);
                fireboltRb.AddForce(direction.normalized * fireboltLaunchForce, ForceMode.Impulse);
                fireboltCooldowned = false;
                StartCoroutine(Cooldown(1));
            }
            else if (useIceball && iceballCooldowned)
            {
                iceballRb.velocity = Vector3.zero;
                Vector3 direction = cursor.transform.position - transform.position;
                iceball.transform.position = transform.position + (direction.normalized*1.2f);
                iceballRb.AddForce(direction.normalized * iceballLaunchForce, ForceMode.Impulse);
                iceballCooldowned = false;
                StartCoroutine(Cooldown(2));
            }
            else if (useBomb && bombCooldowned)
            {
                bombRb.velocity = Vector3.zero;
                Vector3 direction = cursor.transform.position - transform.position;
                bomb.transform.position = transform.position + (direction.normalized * 1.5f);
                bombCooldowned = false;
                StartCoroutine(Cooldown(3));
            }

        }



        // Sets the cursor to be visible or insvisible.
        if (Input.GetKeyDown(KeyCode.V))
        {
            Cursor.visible = !Cursor.visible;
        }
    }

  
    private void FixedUpdate()
    {
        //isGroundedCheck();
        // Gets the left/right input from the user and applies it to the player.
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 force = new Vector3(horizontalInput*moveSpeed, 0f, 0f);
        if ((playerRb.velocity.x < maxSpeed || force.x < 0) && (playerRb.velocity.x > -maxSpeed || force.x > 0))
        {
            playerRb.AddForce(force);
        }
        

        // Makes sure the player has a max speed.
        //playerRb.velocity = new Vector3(Mathf.Clamp(playerRb.velocity.x, -maxSpeed, maxSpeed), playerRb.velocity.y, 0f);
        
        // Slows down the player faster if they are not making any meaningful horizontal inputs.
        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.01f && (playerRb.velocity.x <= maxSpeed+3 && playerRb.velocity.x >= -maxSpeed-3)) {
            playerRb.velocity = new Vector3(playerRb.velocity.x * 0.8f, playerRb.velocity.y, 0f);
        }

        playerRb.AddForce(Vector3.down * 5f);

        // Sets the cursor object to follow the user's mouse to give a visual
        // indication for where they are aiming.
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos = mousePos - Vector3.forward * -20;
        cursor.transform.position = mousePos; 

        
    }

    // Checks that the player is on the ground.
    private void IsGroundedCheck()
    {
        isGrounded = Physics.CheckSphere(groundObject.transform.position, 0.2f, jumpableLayers);
        //Debug.Log(isGrounded);
    }
    
    // Sets all of the tools to false whenever the user switches tools or the next level starts.
    private void SetAllToolsFalse()
    {
        useFirebolt = false;
        useIceball = false;
        useBomb = false;
    }

    // Makes each tool have a cooldown.
    private IEnumerator Cooldown(int num)
    {
        switch (num)
        {
            case 1:
                yield return new WaitForSeconds(2);
                fireboltCooldowned = true;
                break;
            case 2:
                yield return new WaitForSeconds(3);
                iceballCooldowned = true;
                break;
            case 3:
                yield return new WaitForSeconds(5.1f);
                bombCooldowned = true;
                break;
            default:
                Debug.Log("Error in Cooldown method");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Checks if reached the end of the level.
        if (other.gameObject.layer == 11)
        {
            level++;
            //Debug.Log("Check 1");
            ChangeLevel(level);
        }
    }

    public void ChangeLevel(int levelNum)
    {
        Debug.Log("Check 1 - " + level);
        transform.position = levelStarts[levelNum].transform.position;
        Camera.main.transform.position = cameraPositions[levelNum].transform.position;
    }

    // Displays the check the game does to see if the player is grounded.
    // Only displayed in Scene view.
    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(groundObject.transform.position, 0.2f);
    }

}
