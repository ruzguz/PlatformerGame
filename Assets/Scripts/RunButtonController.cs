using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RunButtonController : MonoBehaviour
{

    // Consts
    public const float CHANGE_RATE = 0.2f;

    // General vars 
    bool _isPressed = false;
    float _axis = 0;
    [SerializeField] 
    int _direction;

    // Other GameObject references 
    public PlayerController player;
    public Button otherButton;

    // Start is called on the frame when a script is enabled just before
    // any of the Update methods is called the first time.
    void Start()
    {
        // Getting the other arrow to disable it when this is pressed
        otherButton = GameObject.Find(this.name == "RightArrow"?"LeftArrow":"RightArrow").GetComponent<Button>();
    }

    // Update is called every frame, if the MonoBehaviour is enabled.
    void Update()
    {
        // Calculating player speed and direction
        if (_isPressed) 
        {
            _axis = Mathf.Lerp(_axis, 1, CHANGE_RATE);
            // Move player
            player.Run(_axis * _direction);
        }
    }


    // Action when the player press the run button
    public void Press()
    {
        // if button is disble don't do any action
        if (!GetComponent<Button>().interactable) return;
        // set buttton as pressed and disable the other arrow 
        _isPressed = true;
        otherButton.interactable = false;
        //player._playerAnim.SetBool("isRunning", true);
    }

    // Action when the player stop pressing the run button 
    public void StopPressing() 
    {
        // if button is disble don't do any action
        if (!GetComponent<Button>().interactable) return;
        // Stop the player and enable the other arrow
        _isPressed = false;  
        _axis = 0; 
        player.Run(0);
        otherButton.interactable = true;
        //player._playerAnim.SetBool("isRunning", false);
    }


}

