using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlemode : MonoBehaviour
{
    [SerializeField] GameObject Visualcam1;
    [SerializeField] GameObject Visualcam2;
    [SerializeField] GameObject Battlearea;
    [SerializeField] Enemycontrolscript Check;
    public bool Battlemodeactive = false;
    void Start()
    {
        Battlearea.SetActive(false);
        Visualcam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Battlemodeactive== true) 
        {
            BattlemodeactiveOn();
        }
        else
        {
            BattlemodeactiveOff();
        }
        if(Check.clear == true)
        {
            Destroy(gameObject);
        }
    }

    void BattlemodeactiveOn()
    {
        Visualcam1.SetActive(false);
        Visualcam2.SetActive(true);
        Battlearea.SetActive(true);
    }
    void BattlemodeactiveOff()
    {
        Visualcam1.SetActive(true);
        Visualcam2.SetActive(false);
        Battlearea.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           Battlemodeactive = true;
        }
    }
}
