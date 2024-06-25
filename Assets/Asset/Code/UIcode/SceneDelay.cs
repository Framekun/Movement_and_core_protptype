using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDelay : MonoBehaviour
{
    [SerializeField]private float delay = 5f;
    [SerializeField] private int levelNumber;
    [SerializeField] private int sceneNumber;
    [SerializeField] private bool isGameover;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelNumber = PlayerPrefs.GetInt("Level_Number");
        if(levelNumber == 1)
        {
            if(isGameover == true)
            {
                sceneNumber = 1;
            }
            else if(isGameover == false)
            {
                sceneNumber = 3;
            }
            
        }
        if (levelNumber == 2)
        {
            if (isGameover == true)
            {
                sceneNumber = 3;
            }
            else if (isGameover == false)
            {
                sceneNumber = 0;
            }
        }
        delay -= Time.deltaTime;
        if(delay <= 0 )
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
