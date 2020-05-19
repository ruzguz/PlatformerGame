using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalContorller : MonoBehaviour
{

    SceneChanger _sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        _sceneChanger = GameObject.Find("SceneManager").GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// OnTriggerEnter2D is called when the Collider other enters the trigger.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            _sceneChanger.ChangeToNextScene();
        }
    }
}
