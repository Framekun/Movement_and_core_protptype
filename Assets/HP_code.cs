using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_code : MonoBehaviour
{
    public bool cangetdamage = true;
    public float MaxHp;
    public float currentHp;
    public Image HPBar;
    private Movementcode player;
    void Start()
    {
        currentHp = MaxHp;
        player = gameObject.GetComponent<Movementcode>();
    }

    // Update is called once per frame
    void Update()
    {
        Filler();
        if (currentHp < 0)
        {
            currentHp = 0;
            Debug.Log("Game_over");
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyHitbox")
        {
            if(player.Candamage == true)
            {
                currentHp -= 10;
            }
            
        }
    }
    void Filler()
    {
        Debug.Log("Currentfill"+ currentHp / MaxHp);
        HPBar.fillAmount = currentHp/MaxHp;
    }
}
