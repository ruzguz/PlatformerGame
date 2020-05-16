﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectabels : MonoBehaviour
{

    // Shared vars
    public static int gemsQuantity = 0;

    // General vars
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            gameObject.SetActive(false);
            gemsQuantity++;
            GameObject.Find("GemsText").GetComponent<Text>().text = "x "+gemsQuantity;
        }    
    }
}
