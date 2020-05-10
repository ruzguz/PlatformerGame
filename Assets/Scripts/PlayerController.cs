using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Components vars
    Rigidbody2D _playerRB;
    public Animator _playerAnim;

    // General Vars
    [SerializeField]
    float _speed = 15f;
    [SerializeField]
    float _jumpForce = 25f;
    bool isGrounded = false;
    int scale = 1;


    // Is called when the script instance is loaded
    void Awake() 
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
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
        // Flip player
        if (axis < 0) 
        {
            scale = -1;
        } else if (axis > 0) {
            scale = 1;
        }
        transform.localScale = new Vector3(scale, 1, 1);

        // Change player velocity    
        _playerRB.velocity = new Vector2(axis * _speed, _playerRB.velocity.y);
    }

    // Add force to make the player jump
    public void Jump() 
    {
        if (isGrounded) {
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
