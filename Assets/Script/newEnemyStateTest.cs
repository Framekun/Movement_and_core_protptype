using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class newEnemyStateTest : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyrb;
    [SerializeField] public bool redType;
    [SerializeField] public bool blueType;
    [SerializeField] private float xStopDistance = 2f;
    [SerializeField] private float zStopDistance = 0.5f;
    [SerializeField] private Animator anim;
    [SerializeField] private float attackCooldown = 2f;
    public Hitboxcode player;
    private float difDistance;
    bool canmove;
    public float HP;
    public float ShildHP;
    public float currentHP;
    public float currentShild;
    int Damageget;
    float delay;
    private Enemycontrolscript _controller;
    private Movementcode target;
    float speed = 5f;
    bool readytoattack = false;
    public float attackCooldownTimer;
    public Image HPBar;
    public Image ShildBar;
    public ParticleSystem Partical01;
    public ParticleSystem Partical02;

    void Start()
    {
        currentHP = HP;
        currentShild = ShildHP;
        target = FindObjectOfType<Movementcode>();
        difDistance = Random.value / 4.0f;
        print("number" + difDistance);
        Partical01.Stop();
        Partical02.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Filler();
        UpdateTimers();
        if(canmove) 
        {
            Enemymovement();
            Rotation();
            Attack();
        }
        if (canmove == false)
        {
            delay += Time.deltaTime;
            if (delay >= 2f)
            {
                canmove = true;
                delay = 0;
            }
        }
        if(currentShild <= 0)
        {
            currentShild = 0;
            redType = true;
            blueType = true;
        }
        if (currentHP <= 0)
        {
            Dead();
        }
    }

    public void SetController(Enemycontrolscript controller)
    {
        _controller = controller;
    }

    private void UpdateTimers()
    {
        if (attackCooldownTimer > 0f)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }

    void Enemymovement()
    {
        if (target != null)
        {
            Vector3 PLayerpos = target.transform.position;
            Vector3 Enemy = gameObject.transform.position;
            Vector3 Difpos = PLayerpos - Enemy;
            Difpos.y = 0f;

            readytoattack = true;

            if (Mathf.Abs(Difpos.x) <= xStopDistance + difDistance)
            {
                Difpos.x = 0f;
            }
            else
            {
                readytoattack = false;
            }

            if (Mathf.Abs(Difpos.z) <= zStopDistance + difDistance)
            {
                Difpos.z = 0f;
            }
            else
            {
                readytoattack = false;
            }

            Difpos = Difpos.normalized;

            Vector3 newVelo = Difpos * speed;
            newVelo.y = enemyrb.velocity.y;

            enemyrb.velocity = newVelo;
        }
        else
        {
          //  enemyrb.velocity = new(0, enemyrb.velocity.y, 0);
        }
    }

    void Rotation()
    {
        Vector3 PLayerpos = target.transform.position;
        Vector3 Enemy = gameObject.transform.position;
        Vector3 Difpos = PLayerpos - Enemy;
        if (Difpos.x < 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }
    void Dead()
    {
      //  _controller?.HandleEnemyDeath(this);
        Destroy(gameObject); 
    }
    void Attack()
    {
        if (readytoattack == true && attackCooldownTimer <= 0f)
        {
            anim.SetTrigger("Attack");
            readytoattack = false;
            attackCooldownTimer = attackCooldown;
        }

    }

    void Filler()
    {
        HPBar.fillAmount = currentHP/HP;
        ShildBar.fillAmount = currentShild/ShildHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hitbox")
        {
            if(currentShild > 0)
            {
                Partical01.Play();
            }
            if(currentShild <= 0)
            {
                Partical02.Play();
            }
        }
    }

    public void TakeHit(Hitboxcode hitbox)
    {
        anim.SetTrigger("Damage");
        canmove= false;
        readytoattack = false;
        if (redType == true)
        {
            if (hitbox.redattack == true)
            {
                Damageget = hitbox.Attack;
                currentHP -= Damageget;
            }
            else if (hitbox.redattack == false && ShildHP > 0)
            {
                Damageget = hitbox.Attack;
                currentShild -= Damageget;
            }
        }
        if (blueType == true)
        {
            if (hitbox.Blueattack == true)
            {
                Damageget = hitbox.Attack;
                currentHP -= Damageget;
            }
            else if (hitbox.Blueattack == false && ShildHP > 0)
            {
                Damageget = hitbox.Attack;
                currentShild -= Damageget;
            }
        }
    }
}
