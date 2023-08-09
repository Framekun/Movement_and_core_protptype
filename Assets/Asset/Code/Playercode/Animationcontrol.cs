using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationcontrol : MonoBehaviour
{
    public Animator animator;
    [SerializeField] Movementcode player;
    [SerializeField] Rigidbody Player;
    public int Count = 0;
    bool startdelay = false;
    bool Endcombodelay = false;
    //float Maxdelay = 1f;
    //float delay;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Mouse0) && Endcombodelay == false ) 
        //{
        //    //Attack();
        //    Count += 1;
        //}
        //if (Count > 3)
        //{
        //    Count= 0;
        //}
        //if(startdelay)
        //{
        //    delay += Time.deltaTime;
        //    if(delay >= Maxdelay) 
        //    { 
        //        startdelay= false;
        //        delay= 0f;
        //    }

        //}
        //if(Endcombodelay == true) 
        //{
        //    delay += Time.deltaTime;
        //    if (delay >= 0.7f)
        //    {
        //        Endcombodelay = false;
        //        delay = 0f;
        //    }
        //}
    }

    private void FixedUpdate()
    {
        if (startdelay && Endcombodelay == false)
        {
            Player.velocity = new Vector3(Player.velocity.x, 0, Player.velocity.z);
        }
    }
    void Attack()
    {
       
        if(Count== 0)
        {
            animator.SetTrigger("N_atk00");
            //Player.AddForce(new Vector3(10, Player.velocity.y, Player.velocity.z));
        }

        if (Count == 1)
        {
            animator.SetTrigger("N_atk01");
        }

        if (Count == 2)
        {
            animator.SetTrigger("N_atk02");
        }

    }

    public void Nextattack()
    {
        Debug.Log("Nextcombo");
        //if (Input.GetKeyDown(KeyCode.Mouse0) == true)
        //{
        //    Count += 1;
        //    Attack();
        //}
        startdelay = true;
    }
    public void Stopattack()
    {
        Debug.Log("Endcombo");
        Endcombodelay = true;
        Count = 0;
    }
}
