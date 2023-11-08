using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitboxcode : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody targetrb;
    public GameObject Player;
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

        Vector3 Knock1 = new Vector3(knockx, knocky, 0);
        Vector3 Knock2 = new Vector3(-knockx, knocky, 0);
        if (other.gameObject.tag == "Enemy")
        {
            SetCurrentAttack();

            if (other.TryGetComponent(out newEnemy enemy))
            {
                enemy.TakeHit(this);
            }

            targetrb = other.GetComponent<Rigidbody>();
            //candamage = other.GetComponent<newEnemy>();
            //if(!candamage.isGuardtype) 
            //{
            //    if (candamage.candamageable == true)
            //    {
            if (other.gameObject.transform.position.x - Player.transform.position.x >= 0)
            {
                targetrb.AddForce(Knock1, ForceMode.Impulse);
            }
            if (other.gameObject.transform.position.x - Player.transform.position.x < 0)
            {
                targetrb.AddForce(Knock2, ForceMode.Impulse);
            }
            //    }

            //}

        }
    }
}
