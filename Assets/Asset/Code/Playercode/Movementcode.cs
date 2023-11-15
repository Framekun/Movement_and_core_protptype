using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Movementcode : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed = 15;
    [SerializeField] float Jumppower = 10;
    [SerializeField] float DecelerationWhileAttacking = 40f;
    [SerializeField] AudioSource Jumpsound;
    [SerializeField] AudioSource Knocksound;
    [SerializeField] HP_code HP;
    [SerializeField] float pushforce;
    [SerializeField] bool pushNow = false;
    [SerializeField] private Camera _camera;

    public AttackBox Damage;
    public Animator anim;
    public bool Onground = true;
    bool isrolling = false;
    public bool canmove => canmovecheck;
    [SerializeField] private bool canmovecheck;
    public bool Candamage = true;
    float delay = 0;
    public ParticleSystem Partical;

    private float _facingDirection = 1f;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        Partical.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        AlignWithCam();

        if (canmovecheck == true)
        {
            Movement();
            Jump();
            Candamage = true;
        }
        if(Candamage == false)
        {
            delay += Time.deltaTime;
            if (delay > 2f)
            {
                Candamage = true;
                delay = 0f;
            }
        }
        if(pushNow == true)
        {
            pushcharacter();
        }
        else
        {
            Vector3 planeVelocity = rb.velocity;
            planeVelocity.y = 0f;
            planeVelocity = Vector3.MoveTowards(planeVelocity, Vector3.zero, Time.deltaTime * DecelerationWhileAttacking);
            rb.velocity = new Vector3(planeVelocity.x, rb.velocity.y, planeVelocity.z);
        }
        if (Onground == false)
        {
            anim.SetBool("Isfalling", true);
        }
        else
        {
            anim.SetBool("Isfalling", false);
        }
    }

    void AlignWithCam()
    {
        transform.rotation = Quaternion.LookRotation(ScreenForward , Vector3.up);
    }

    void Movement()
    {
        if (isrolling) return;

        if (Input.GetKey(KeyCode.W) == true)
        {
            rb.velocity = ScreenForward * Speed + Vector3.ProjectOnPlane(rb.velocity, ScreenForward);
            anim.SetBool("Isrunning", true);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            rb.velocity = -ScreenForward * Speed + Vector3.ProjectOnPlane(rb.velocity, ScreenForward);
            anim.SetBool("Isrunning", true);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            _facingDirection = -1f;
            transform.localScale = new Vector3(-_initialScale.x, _initialScale.y, _initialScale.z);
            AlignWithCam();
            rb.velocity = -ScreenRight * Speed + Vector3.ProjectOnPlane(rb.velocity, ScreenRight);
            anim.SetBool("Isrunning", true);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            _facingDirection = 1f;
            transform.localScale = new Vector3(_initialScale.x, _initialScale.y, _initialScale.z);
            AlignWithCam();
            rb.velocity = ScreenRight * Speed + Vector3.ProjectOnPlane(rb.velocity, ScreenRight);
            anim.SetBool("Isrunning", true);
        }
        else if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.D) == false)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            anim.SetBool("Isrunning", false);
        }

    }

    void Jump()
    {
        Vector3 Jumpig = new Vector3(0, Jumppower, 0);
        if (Input.GetKeyDown(KeyCode.Space) && Onground == true) 
        {
            anim.SetTrigger("Jump");
            rb.AddForce(Jumpig,ForceMode.Impulse);
            rb.velocity = Jumpig;
            Onground = false;
            Jumpsound.Play();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Onground =true;
        }
;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Onground = true;
        }
;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Onground = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyHitbox")
        {
            Damage = other.GetComponent<AttackBox>();
            if(Candamage == true)
            {
                anim.SetTrigger("Damage");
                Partical.Play();
                Candamage = false;
                Knocksound.Play();
                HP.currentHp -= Damage.Attack;
            }  
        }
    }

    public void Endrolling()
    {
        isrolling= false;
    }

   void pushcharacter()
    {
        if(_facingDirection == 1f)
        {
            transform.localScale = new Vector3(_initialScale.x, _initialScale.y, _initialScale.z);
            AlignWithCam();
            rb.velocity = ScreenRight * pushforce + Vector3.ProjectOnPlane(rb.velocity, ScreenRight);
        }
        if (_facingDirection == -1f)
        {
            transform.localScale = new Vector3(-_initialScale.x, _initialScale.y, _initialScale.z);
            AlignWithCam();
            rb.velocity = -ScreenRight * pushforce + Vector3.ProjectOnPlane(rb.velocity, ScreenRight);
        }
    }
}
