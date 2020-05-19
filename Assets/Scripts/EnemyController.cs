using System.Collections;
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
        enemyParticle.transform.position = new Vector3(transform.position.x, 
                                                       transform.position.y,
                                                       enemyParticle.transform.position.z);
        enemyParticle.Play();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Player kill enemy
        if (other.gameObject.CompareTag("Player") && other.transform.position.y >= transform.position.y + 1f) {
            _enemyAnim.SetBool("isAlive", false);
            _enemyAudio.Play();
            return;
        } 
        // Enemy attack player
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.GetComponent<PlayerController>().Kill();
            Transform parent = transform.parent;
            GetComponentInParent<AudioSource>().Play();
            // Revive all enemies
            for (int i =  0; i < parent.childCount; i++) 
            {
                parent.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
