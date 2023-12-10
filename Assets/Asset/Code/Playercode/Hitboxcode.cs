using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitboxcode : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody targetrb;
    public Movementcode PlayerMovement;
    public int BaseAttack;
    public int Attack;
    public float knockx;
    public float knocky;
    public CinemachineImpulseSource cinima;

    private void Awake()
    {
        Attack = BaseAttack;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetCurrentAttack()
    {
      
            Attack = BaseAttack;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name);

        Vector3 Knock = new Vector3(knockx, knocky, 0);
        Knock.x *= PlayerMovement.FacingDirection*100;

        Knock = PlayerMovement.transform.rotation * Knock;

        if (other.gameObject.tag == "Enemy")
        {
            SetCurrentAttack();

            if (other.TryGetComponent(out newEnemy enemy))
            {
                enemy.TakeHit(this);
            }

            targetrb = other.GetComponent<Rigidbody>();

            targetrb.AddForce(Knock, ForceMode.Impulse);

            //candamage = other.GetComponent<newEnemy>();
            //if(!candamage.isGuardtype) 
            //{
            //    if (candamage.candamageable == true)
            //    {
            //if (other.gameObject.transform.position.x - Player.transform.position.x >= 0)
            //{
            //    targetrb.AddForce(Knock1, ForceMode.Impulse);
            //}
            //if (other.gameObject.transform.position.x - Player.transform.position.x < 0)
            //{
            //    targetrb.AddForce(Knock2, ForceMode.Impulse);
            //}
            //    }

            //}

        }
    }
}
