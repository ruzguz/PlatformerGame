using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunButtonController : MonoBehaviour
{

    // Consts
    public const float CHANGE_RATE = 0.1f;

    // General vars 
    bool _isPressed = false;
    float _axis = 0;
    [SerializeField] 
    int _direction;

    // Other GameObject references 
    public PlayerController player;


    // Update is called every frame, if the MonoBehaviour is enabled.
    void Update()
    {
        // Calculating player speed and direction
        if (_isPressed) 
        {
            _axis = _axis = Mathf.Lerp(_axis, 1, CHANGE_RATE);
            // Move player
            player.Run(_axis * _direction);
        }

        Debug.Log(_axis);
    }


    // Action when the player press the run button
    public void Press()
    {

        _isPressed = true;
    }

    // Action when the player stop pressing the run button 
    public void StopPressing() 
    {
        _isPressed = false;  
        _axis = 0; 
        player.Run(0);
    }


}

