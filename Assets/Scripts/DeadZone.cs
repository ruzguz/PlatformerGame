using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    
    // Component vars
    AudioSource _deadZoneAudio;

    
    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        _deadZoneAudio = GetComponent<AudioSource>();    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Kill();
            _deadZoneAudio.Play();
        }
    }
}
