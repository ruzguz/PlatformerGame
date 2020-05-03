using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Components vars
    Rigidbody2D _playerRB;

    // General Vars
    [SerializeField]
    float _speed = 10f;


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

    }

    public void Run(float axis) 
    {
        // Change player velocity 
        _playerRB.velocity = new Vector2(axis * _speed, _playerRB.velocity.y);
    }


}
