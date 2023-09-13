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
    [SerializeField] AudioSource Footsound;
    [SerializeField] AudioSource Jumpsound;
    [SerializeField] AudioSource Knocksound;
    [SerializeField] private Camera _camera;

    public AttackBox Damage;
    public Animator anim;
    public bool Onground = true;
    bool isrolling = false;
    public int HP;
    bool canmove = true;
    public bool canmovecheck;
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
        Damage = FindObjectOfType<AttackBox>();
        Partical.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        AlignWithCam();

        canmovecheck = canmove;
        if (canmove == true)
        {
            Movement();
            Jump();
            Rolling();
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
        else
        {
            Vector3 planeVelocity = rb.velocity;
            planeVelocity.y = 0f;
            planeVelocity = Vector3.MoveTowards(planeVelocity, Vector3.zero, Time.deltaTime * DecelerationWhileAttacking);
            rb.velocity = new Vector3(planeVelocity.x, rb.velocity.y, planeVelocity.z);
        }
        if(canmove == false)
        {
            delay += Time.deltaTime;
            if(delay > 1f)
            {
                canmove = true;
                delay = 0f;
            }
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
            Footsound.Play();
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            rb.velocity = -ScreenForward * Speed + Vector3.ProjectOnPlane(rb.velocity, ScreenForward);
            anim.SetBool("Isrunning", true);
            Footsound.Play();
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            _facingDirection = -1f;
            transform.localScale = new Vector3(-_initialScale.x, _initialScale.y, _initialScale.z);
            AlignWithCam();
            rb.velocity = -ScreenRight * Speed + Vector3.ProjectOnPlane(rb.velocity, ScreenRight);
            anim.SetBool("Isrunning", true);
            Footsound.Play();
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            _facingDirection = 1f;
            transform.localScale = new Vector3(_initialScale.x, _initialScale.y, _initialScale.z);
            AlignWithCam();
            rb.velocity = ScreenRight * Speed + Vector3.ProjectOnPlane(rb.velocity, ScreenRight);
            anim.SetBool("Isrunning", true);
            Footsound.Play();
        }
        else if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.D) == false)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            anim.SetBool("Isrunning", false);
            Footsound.Stop();

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

    void Rolling()
    {
        Vector3 Roll = new Vector3(30, 0, rb.velocity.z);
        Vector3 Roll2 = new Vector3(-30, 0, rb.velocity.z);
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            if(rb.transform.eulerAngles.y == 0)
            {
                rb.velocity = Roll;

            }
            if (rb.transform.eulerAngles.y == 180)
            {
                rb.velocity = Roll2;

            }
            anim.SetTrigger("Rolling");
            isrolling = true;

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
            if(Candamage == true)
            {
                canmove = false;
                anim.SetTrigger("Damage");
                Partical.Play();
                Candamage = false;
                Knocksound.Play();
            }  
        }
    }

    public void Endrolling()
    {
        isrolling= false;
    }

    public void AddforceattackX(float forceStrength)
    {
        rb.AddRelativeForce(new Vector3(forceStrength, 0f, 0f), ForceMode.Impulse);
    }

    public void AddforceattackY(float forceStrength)
    {
        rb.AddRelativeForce(new Vector3(0f, forceStrength, 0f), ForceMode.Impulse);
    }
}
