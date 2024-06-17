using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP_code : MonoBehaviour
{
    public float MaxHp;
    public float currentHp;
    public Image HPBar;
    void Start()
    {
        currentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        Filler();
        if (currentHp <= 0)
        {
            currentHp = 0;
            //Debug.Log("Game_over");
            gameObject.SetActive(false);
            SceneManager.LoadScene(6);
        }
    }
    void Filler()
    {
        //Debug.Log("Currentfill"+ currentHp / MaxHp);
        HPBar.fillAmount = currentHp/MaxHp;
    }
}
