using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycode : MonoBehaviour
{
    [SerializeField] Rigidbody enemyrb;
    [SerializeField] public bool redType;
    [SerializeField] public bool blueType;
    public int currentHP;
    int Damageget;
    public Hitboxcode player;
    public GameObject Attaclbox;
    public GameObject Playercharacter;
    public Rigidbody Enemycharacter;
    public Animator animator;
    public Stamina_code stamina;
    float speed = 2f;
    bool isattacked = false;
    public bool canmove = true;
    public bool Canattack = true;
    public float delay = 0;
    float attackdelay = 2.0f;
    float maxdelay = 0.5f;
    public bool candamageable = true;
    public bool isGuardtype;

    private Enemycontrolscript _controller;

    void Start()
    {
        candamageable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isattacked == false)
        {
            enemyMovement();
            //Attack();
        }

        if (isattacked == true)
        {
            delay += Time.deltaTime;
            if(delay >= maxdelay ) 
            { 
                isattacked = false;
                delay= 0;
            }
        }
       if(currentHP <= 0 && isattacked == false) 
        {
            //_controller?.HandleEnemyDeath(this);
            Destroy(gameObject);
        } 
    }

    public void SetController(Enemycontrolscript controller)
    {
        _controller = controller;
    }

    void enemyMovement()
    {
        if(Playercharacter != null && canmove == true) 
        {
            Vector3 PLayerpos = Playercharacter.transform.position;
            Vector3 Enemy = gameObject.transform.position;
            Vector3 Difpos = PLayerpos- Enemy;
            Difpos.y = 0f;
            Difpos = Difpos.normalized;

            Vector3 newVelo = Difpos * speed;
            newVelo.y = enemyrb.velocity.y;

            enemyrb.velocity = newVelo;
        }
        else
        {
            enemyrb.velocity = new(0,enemyrb.velocity.y,0);
        }
    }

    void Attack()
    {
        if(Canattack ==true)
        {
            canmove= false;
            Vector3 PLayerpos = Playercharacter.transform.position;
            Vector3 Enemy = gameObject.transform.position;
            Vector3 Difpos = PLayerpos - Enemy;
            if (Difpos.x > 0)
            {
                
                enemyrb.velocity = new Vector3(10, enemyrb.velocity.y, 0);
                animator.SetTrigger("Attack");
                print("AttackRight");
                Canattack= false;
            }
            if (Difpos.x < 0)
            {
                
                enemyrb.velocity = new Vector3(-10, enemyrb.velocity.y, 0);
                animator.SetTrigger("Attack");
                print("AttackLeft");
                Canattack = false;
            }


            //StartCoroutine(Delay());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hitbox")
        {
            if(candamageable== true) 
            {
                other.GetComponent<Hitboxcode>();
                isattacked = true;
                Damageget = player.Attack;
                currentHP -= Damageget;

            }
           
        }
        Vector3 Knock1 = new Vector3(10, 3, 0);
        Vector3 Knock2 = new Vector3(-10, 3, 0);
        //if (other.gameObject.tag == "Player")
        //{
        //    Enemycharacter = other.GetComponent<Rigidbody>();

        //    if (other.gameObject.transform.position.x - gameObject.transform.position.x >= 0)
        //    {

        //        //Enemycharacter.AddForce(Knock1, ForceMode.Impulse);
        //        Enemycharacter.velocity = Knock1;
        //    }
        //    if (other.gameObject.transform.position.x - gameObject.transform.position.x < 0)
        //    {
        //        //Enemycharacter.AddForce(Knock2, ForceMode.Impulse);
        //        Enemycharacter.velocity = Knock2;

        //    }

        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canmove= true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canmove = false;
        }
    }
    //IEnumerator Delay()
    //{
    //    Canattack= false;
    //    yield return new WaitForSeconds(attackdelay);
    //    canmove= true;
    //    print("Canmove");
    //    Canattack = true;
    //    print("CanAttack");
    //}

}
