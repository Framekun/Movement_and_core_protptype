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
        Visualcam1.SetActive(false);
        Visualcam2.SetActive(true);

    }
    void BattlemodeactiveOff()
    {
        Visualcam1.SetActive(true);
        Visualcam2.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BattlemodeactiveOn();
        }
    }


}
