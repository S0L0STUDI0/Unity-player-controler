//   _  _    _____       _       _____ _             _ _       
// _| || |_ / ____|     | |     / ____| |           | (_)      
//|_  __  _| (___   ___ | | ___| (___ | |_ _   _  __| |_  ___  
// _| || |_ \___ \ / _ \| |/ _ \\___ \| __| | | |/ _` | |/ _ \ 
//|_  __  _|____) | (_) | | (_) |___) | |_| |_| | (_| | | (_) |
//  |_||_| |_____/ \___/|_|\___/_____/ \__|\__,_|\__,_|_|\___/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Change these to edit speed, sprint speed, jump force.
    public float speed = 5.0f;
    public float sprintSpeed = 6.0f;
    public float jumpForce = 5;
    public bool isOnGround = true;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Check for sprinting
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        // Move player
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * currentSpeed * horizontalInput);

        // Player jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}

//SoloStudio-2024
