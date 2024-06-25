using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    void Start()
    {
        PlayerPrefs.SetInt("Level_Number", levelNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            SceneManager.LoadScene(5);
        }
    }
}
