using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;

public class newEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyrb;
    [SerializeField] private float xStopDistance = 2f;
    [SerializeField] private float zStopDistance = 0.5f;
    [SerializeField] private Animator anim;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] AudioSource Knocksound;
    [SerializeField] private Camera _camera;
    [SerializeField] private ScoreHolder _scoreHolder;
    [SerializeField] private bool ishit;
    [SerializeField] private string Moveanimation;
    [SerializeField] private string Attackanimation;
    [SerializeField] private string Damageanimation;
    [SerializeField] private string Diedanimation;
    private float difDistance;
    bool canmove;
    public float HP;
    public float currentHP;
    int Damageget;
    float delay;
    float Dieddelay;
    private Enemycontrolscript _controller;
    private Movementcode target;
    public float speed = 5f;
    bool readytoattack = false;
    public float attackCooldownTimer;
    public Image HPBar;
    public ParticleSystem Partical01;
    public ParticleSystem Partical02;

    private Vector3 _initialScale;

    public Vector3 ScreenForward
    {
        get
        {
            return Vector3.ProjectOnPlane(_camera.transform.forward, Vector3.up);
        }
    }

    public Vector3 ScreenRight
    {
        get
        {
            return Vector3.ProjectOnPlane(_camera.transform.right, Vector3.up);
        }
    }

    private void Awake()
    {
        _initialScale = transform.localScale;
        _camera = FindAnyObjectByType<Camera>();
    }

    void Start()
    {
        currentHP = HP;
        target = FindObjectOfType<Movementcode>();
        difDistance = Random.value / 4.0f;
        print("number" + difDistance);
        Partical01.Stop();
        Partical02.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        AlignWithCam();


        if (canmove) 
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
                ishit = false;
                canmove = true;
                delay = 0;
            }
        }
        if (currentHP <= 0 && ishit == false)
        {
            canmove = false;
            anim.SetBool(Diedanimation, true);
            Dieddelay += Time.deltaTime;
            if(Dieddelay >= 2)
            {
                Dead();
            }

        }
    }
    private void FixedUpdate()
    {
        if(HPBar != null)
        {
            Filler();
        }

        UpdateTimers();
    }

    void AlignWithCam()
    {
        transform.rotation = Quaternion.LookRotation(ScreenForward, Vector3.up);
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
            anim.SetBool(Moveanimation,true);
        }
        else
        {
            enemyrb.velocity = new(0, enemyrb.velocity.y, 0);
            anim.SetBool(Moveanimation, false);
        }
    }

    void Rotation()
    {
        Vector3 PLayerpos = target.transform.position;
        Vector3 Enemy = gameObject.transform.position;
        Vector3 Difpos = PLayerpos - Enemy;
        if (Difpos.x < 0)
        {
            transform.localScale = new Vector3(_initialScale.x, _initialScale.y, _initialScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-_initialScale.x, _initialScale.y, _initialScale.z);
        }
    }
    void Dead()
    {
        
        _controller?.HandleEnemyDeath(this);
        Destroy(gameObject); 
    }
    void Attack()
    {
        if (readytoattack == true && attackCooldownTimer <= 0f)
        {
            attackCooldownTimer = attackCooldown;
            canmove = false;
            anim.SetTrigger(Attackanimation);
            readytoattack = false; 
        }

    }

    void Filler()
    {
        HPBar.fillAmount = currentHP/HP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hitbox")
        {
            Partical02.Play();
        }
    }

    public void TakeHit(Hitboxcode hitbox)
    {
        anim.SetTrigger(Damageanimation);
        Knocksound.Play();
        canmove= false;
        readytoattack = false;
        Damageget = hitbox.Attack;
        currentHP -= Damageget;
        ishit = true;
    }
}
