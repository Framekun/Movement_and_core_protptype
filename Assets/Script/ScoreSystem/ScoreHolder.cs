using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public int Score;
    [SerializeField] int ScoreReader; // is not supposed to be touched.
    
    private void Awake()
    {
        if(PlayerPrefs.HasKey("ScoreHolder") == false)
        {
            PlayerPrefs.SetInt("ScoreHolder", Score);
        }
    }
    private void Update()
   {
        if (PlayerPrefs.HasKey("ScoreHolder") == true)
        {
            ScoreReader = PlayerPrefs.GetInt("ScoreHolder");
        }
    }
    public void ResetScoreTest()
    {
        PlayerPrefs.SetInt("ScoreHolder", 0);
    }
    public void AddScoreTest()
    {
        // Use this code for enemy.
        int scoretest;
        scoretest = PlayerPrefs.GetInt("ScoreHolder");
        scoretest += 10;
        PlayerPrefs.SetInt("ScoreHolder", scoretest);
    }
}
 