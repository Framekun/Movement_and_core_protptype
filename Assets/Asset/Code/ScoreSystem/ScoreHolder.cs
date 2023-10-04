using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public int scoretest;
    //[SerializeField] int ScoreReader; // is not supposed to be touched.
    
    private void Awake()
    {
        if(PlayerPrefs.HasKey("ScoreHolder") == false)
        {
            PlayerPrefs.SetInt("ScoreHolder", scoretest);
        }
        if (PlayerPrefs.HasKey("ScoreHolder") == true)
        {
           scoretest = PlayerPrefs.GetInt("ScoreHolder");
        }
    }
    private void Update()
   {
        //if (PlayerPrefs.HasKey("ScoreHolder") == true)
        //{
        //    scoretest = ScoreReader;
        //}
        if (PlayerPrefs.HasKey("ScoreHolder") == true)
        {
            PlayerPrefs.SetInt("ScoreHolder", scoretest);
        }
    }
    //public void ResetScoreTest()
    //{
    //    PlayerPrefs.SetInt("ScoreHolder", 0);
    //}
    //public void AddScoreTest()
    //{
    //    // Use this code for enemy.
        
    //    scoretest = PlayerPrefs.GetInt("ScoreHolder");
    //    scoretest += 10;
    //    PlayerPrefs.SetInt("ScoreHolder", scoretest);
    //}
}
 