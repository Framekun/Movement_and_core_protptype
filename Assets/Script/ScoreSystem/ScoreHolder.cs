using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public int Score;
    private void Awake()
    {
        if(PlayerPrefs.HasKey("ScoreHolder") == false)
        {
            PlayerPrefs.SetInt("ScoreHolder", Score);
        }
    }
    ///private void Update()
 //   {
   /// }
    public void ResetScoreTest()
    {
        PlayerPrefs.SetInt("ScoreHolder", 0);
    }
}
 