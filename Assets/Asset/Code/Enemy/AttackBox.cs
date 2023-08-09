using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public Rigidbody targetrb;
    public GameObject Enemychar;
    //public Enemycode enemycode;
    public int Attack = 5;
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 Knock1 = new Vector3(100, 30, 0);
        Vector3 Knock2 = new Vector3(-100, 30, 0);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("HIT");
            targetrb = other.GetComponent<Rigidbody>();

            if (other.gameObject.transform.position.x - Enemychar.transform.position.x >= 0)
            {
                
                targetrb.AddForce(Knock1, ForceMode.Impulse);
                
            }
            if (other.gameObject.transform.position.x - Enemychar.transform.position.x < 0)
            {
                targetrb.AddForce(Knock2, ForceMode.Impulse);

            }

        }
    }
}
