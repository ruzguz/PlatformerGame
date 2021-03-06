﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Components vars
    Rigidbody2D _playerRB;
    public Animator _playerAnim;
    AudioSource _playerAudio;


    // General Vars
    [SerializeField]
    float _speed = 15f;
    [SerializeField]
    float _jumpForce = 25f;
    bool isGrounded = false;
    int scale = 1;
    [SerializeField]
    float maxFallVelocity = -20f;
    float clamppedYSpeed = 0;


    // Is called when the script instance is loaded
    void Awake() 
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            // Move player with keyboard (test in PC)
            if (Input.GetAxis("Horizontal") != 0) {
                Run(Input.GetAxis("Horizontal"));
            }

            // Check player velocity for the run animation
            if (_playerRB.velocity.x == 0)  
            {
                _playerAnim.SetBool("isRunning", false);
            }
            

            // Jump with keyboard  (test in PC)
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) 
            {
                Jump();
            }
    }


    void FixedUpdate() 
    {
        // Clamp fall speed
        clamppedYSpeed = Mathf.Max(_playerRB.velocity.y, maxFallVelocity);
        _playerRB.velocity = new Vector3(_playerRB.velocity.x, clamppedYSpeed);
    }


    // Change player velocity in x axi 
    public void Run(float axis) 
    {
        // Flip player
        if (axis < 0) 
        {
            scale = -1;
        } else if (axis > 0) {
            scale = 1;
        } 

        // Set animation
        _playerAnim.SetBool("isRunning", axis == 0?false:true);

        transform.localScale = new Vector3(scale, 1, 1);

        // Change player velocity    
        _playerRB.velocity = new Vector2(axis * _speed, _playerRB.velocity.y);
    }

    // Add force to make the player jump
    public void Jump() 
    {
        if (isGrounded) {
            _playerAudio.Play();
            _playerAnim.SetTrigger("jump");
            _playerRB.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }    
    }


}
