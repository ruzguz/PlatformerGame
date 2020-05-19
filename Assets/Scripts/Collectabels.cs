using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectabels : MonoBehaviour
{

    // Static vars
    public static int gemsQuantity = 0;
    public static ParticleSystem diamondParticle;
   
    // Component vars
    AudioSource _diamondAudio;
   
    // General vars
    
    


    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        _diamondAudio = GetComponentInParent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        diamondParticle =  GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.CompareTag("Player")) 
        {       
            _diamondAudio.Play();
            gameObject.SetActive(false);
            gemsQuantity++;
            GameObject.Find("GemsText").GetComponent<Text>().text = "x "+gemsQuantity;
            diamondParticle.transform.position = new Vector3(transform.position.x, 
                                                             transform.position.y,
                                                             diamondParticle.transform.position.z);
            diamondParticle.Play();
        }    
    }
}
