using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Components vars
    Rigidbody2D _playerRB;

    // General Vars
    [SerializeField]
    float _speed = 15f;
    [SerializeField]
    float _jumpForce = 25f;


    // Is called when the script instance is loaded
    void Awake() 
    {
        _playerRB = GetComponent<Rigidbody2D>();
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
            

            // Jump with keyboard  (test in PC)
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) 
            {
                Jump();
            }
    }


    // Change player velocity in x axi 
    public void Run(float axis) 
    {
        // Change player velocity 
        _playerRB.velocity = new Vector2(axis * _speed, _playerRB.velocity.y);
    }

    // Add force to make the player jump
    public void Jump() 
    {
        _playerRB.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    // Check if player is touching the ground
    bool IsTouchinTheGround() 
    {
        return true;
    }


}
