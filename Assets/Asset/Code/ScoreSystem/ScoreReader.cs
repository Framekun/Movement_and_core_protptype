using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreReader : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreDisplay;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        int Score = PlayerPrefs.GetInt("ScoreHolder");
        ScoreDisplay.text = Score.ToString();
    }
}
