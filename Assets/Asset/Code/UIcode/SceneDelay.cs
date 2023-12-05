using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDelay : MonoBehaviour
{
    [SerializeField]private float delay = 5f;
    [SerializeField] private int levelNumber;
    [SerializeField] private int sceneNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelNumber = PlayerPrefs.GetInt("Level_Number");
        if(levelNumber == 1)
        {
            sceneNumber = 3;
        }
        if (levelNumber == 2)
        {
            sceneNumber = 0;
        }
        delay -= Time.deltaTime;
        if(delay <= 0 )
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
