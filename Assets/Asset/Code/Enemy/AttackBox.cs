using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public Rigidbody targetrb;
    public GameObject Enemychar;
    public newEnemy enemycode;
    public int Attack = 5;
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 Knock = new Vector3(500, 0, 0);
        Knock.x = enemycode.FacingDirection;
        Knock = enemycode.transform.rotation * Knock * 2500;
        if (other.gameObject.tag == "Player")
        {
            if (other.TryGetComponent(out Movementcode movementcode))
            {
                movementcode.TakeHit(this);
            }
            targetrb = other.GetComponent<Rigidbody>();
            targetrb.AddForce(Knock, ForceMode.Impulse);

        }
    }
}
