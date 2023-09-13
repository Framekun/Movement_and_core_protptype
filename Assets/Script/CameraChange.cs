using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] GameObject Visualcam1;
    [SerializeField] GameObject Visualcam2;
    [SerializeField] GameObject CameraTrigger1;
    //[SerializeField] GameObject CameraTrigger2;

    //[SerializeField] Enemycontrolscript Check;
    //public bool Battlemodeactive = false;
    //void Start()
    //{
    //    Visualcam2.SetActive(false);
    //}

    // Update is called once per frame
    void Update()
    {
        //if (Battlemodeactive == true)
        //{
            //BattlemodeactiveOn();
        //}
        //else
        //{
        //    BattlemodeactiveOff();
        //}
        //if (Check.clear == true)
        //{
        //    Destroy(gameObject);
        //}
    }

    void BattlemodeactiveOn()
    {
        if(Visualcam1.activeSelf == true)
        {
            Visualcam1.SetActive(false);
            Visualcam2.SetActive(true);
        }
        else if (Visualcam2.activeSelf == true)
        {
            Visualcam2.SetActive(false);
            Visualcam1.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BattlemodeactiveOn();
        }
    }


}
