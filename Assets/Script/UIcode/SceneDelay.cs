using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDelay : MonoBehaviour
{
    [SerializeField]private float delay = 5f;   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay <= 0 )
        {
            SceneManager.LoadScene(0);
        }
    }
}
