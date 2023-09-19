using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Missioncode : MonoBehaviour
{
    public float Timelimited;
    public float currenttime;
    float rectime;
    public TextMeshProUGUI textMeshProUGUI;
    public GameObject Gameover;
    public GameObject Gameclear;
    public Enemycontrolscript check;
    float delay = 0;
    void Start()
    {
        currenttime = Timelimited;
        Gameclear.SetActive(false);
        Gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rectime = currenttime;
        textMeshProUGUI.text = currenttime.ToString();
        if(check.clear == false ) 
        {
            currenttime -= Time.deltaTime;
        }
        if (currenttime <= 0 && check.clear == false) 
        {
            Gameover.SetActive(true);
            currenttime = 0;
            delay += Time.deltaTime;
            if(delay >= 3)
            {
                SceneManager.LoadScene(0);
            }
        }
        if (currenttime > 0 && check.clear == true)
        {
            Gameclear.SetActive(true);
            currenttime = rectime;
            delay += Time.deltaTime;
            if (delay >= 3)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
