﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    // Static vars
    public static ParticleSystem enemyParticle;

    // Component vars
    Rigidbody2D _enemyRB;
    Animator _enemyAnim;
    AudioSource _enemyAudio;

    // General vars
    float _timeBeforeChange;
    [SerializeField]
    float _dealy = 1;
    [SerializeField]
    float speed = 5;



    void Awake() 
    {
        _enemyRB = GetComponent<Rigidbody2D>();
        _enemyAnim = GetComponent<Animator>();
        _enemyAudio = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        enemyParticle = GameObject.Find("EnemyParticle").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        _enemyRB.velocity = Vector2.right * speed;
        if (_timeBeforeChange < Time.time) 
        {
            speed *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
            _timeBeforeChange = Time.time + _dealy;
        }
    }

    public void DisableEnemy() 
    {
        gameObject.SetActive(false);
        enemyParticle.transform.position = transform.position;
        enemyParticle.Play();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Player kill enemy
        if (other.gameObject.CompareTag("Player")) {
            _enemyAnim.SetBool("isAlive", false);
            _enemyAudio.Play();
        } 
    }
}
