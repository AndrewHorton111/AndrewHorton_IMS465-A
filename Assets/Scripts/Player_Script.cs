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

    private float moveSpeed = 100f;
    private float maxSpeed = 5f;
    private float jumpForce = 8f;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the player jump when they hit the space key, if they are on the ground.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGroundedCheck();
            if (isGrounded)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    // Runs 60 times a second.
    private void FixedUpdate()
    {
        //isGroundedCheck();
        // Gets the left/right input from the user and applies it to the player.
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 force = new Vector3(horizontalInput*moveSpeed, 0f, 0f);
        playerRb.AddForce(force);

        // Makes sure the player has a max speed.
        playerRb.velocity = new Vector3(Mathf.Clamp(playerRb.velocity.x, -maxSpeed, maxSpeed), playerRb.velocity.y, 0f);
        
        // Slows down the player faster if they are not making any meaningful horizontal inputs.
        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.01f) {
            playerRb.velocity = new Vector3(playerRb.velocity.x * 0.8f, playerRb.velocity.y, 0f);
        }

        playerRb.AddForce(Vector3.down * 5f);
        

        //if (transform.position.y > 3.1 ){
        //    Debug.Log("Vertical Velocity: " + playerRb.velocity.y);
        //}
    }

    // Checks that the player is on the ground.
    private void isGroundedCheck()
    {
        isGrounded = Physics.CheckSphere(groundObject.transform.position, 0.2f, jumpableLayers);
        Debug.Log(isGrounded);
    }

    // Displays the check the game does to see if the player is grounded.
    // Only displayed in Scene view.
    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(groundObject.transform.position, 0.2f);
    }

}
