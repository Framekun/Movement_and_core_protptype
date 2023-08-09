using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Stamina_code : MonoBehaviour
{
    public float redstamina;
    public float bluestamina;
    public float currentredstamina;
    public float currentbluestamina;
    public Image Stamina_bar;
    public Image Stamina_bar2;

    void Start()
    {
        currentredstamina = redstamina/2;
        currentbluestamina = bluestamina/2;

    }

    void Update()
    {
        Filler();
        if (currentredstamina <= 0)
        {
            currentredstamina = 0;
        }
        if (currentbluestamina <= 0)
        {
            currentbluestamina = 0;
        }
        if (currentredstamina >= redstamina)
        {
            currentredstamina = redstamina;
        }
        if (currentbluestamina >= bluestamina)
        {
            currentbluestamina = bluestamina;
        }
    }
     void Filler()
    {
        Stamina_bar.fillAmount= currentbluestamina/bluestamina;
        Stamina_bar2.fillAmount = currentredstamina/redstamina;
    }
}
