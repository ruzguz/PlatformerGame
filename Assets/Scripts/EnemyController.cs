using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

// Component vars
Rigidbody2D _enemyRB;

// General vars
float _timeBeforeChange;
[SerializeField]
float _dealy = 2;
[SerializeField]
float speed = 5;


    void Awake() 
    {
        _enemyRB = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _enemyRB.velocity = Vector2.right * speed;
        if (_timeBeforeChange < Time.time) 
        {
            speed *= -1;
            _timeBeforeChange = Time.time + _dealy;
        }
    }
}
