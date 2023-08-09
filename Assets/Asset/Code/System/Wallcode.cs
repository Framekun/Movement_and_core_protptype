using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallcode : MonoBehaviour
{
    public Rigidbody targetrb;
    public GameObject Wall; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 Knock1 = new Vector3(5, 1, 0);
        Vector3 Knock2 = new Vector3(-5, 1, 0);
        if (collision.gameObject.tag == "Enemy")
        {
            targetrb = collision.rigidbody;
            if (collision.gameObject.transform.position.x - Wall.transform.position.x >= 0)
            {
                targetrb.AddForce(Knock1, ForceMode.Impulse);
            }
            if (collision.gameObject.transform.position.x - Wall.transform.position.x < 0)
            {
                targetrb.AddForce(Knock2, ForceMode.Impulse);
            }
        }
    }
}
