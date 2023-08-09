using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Attacksystem : MonoBehaviour
{
    public Stamina_code stamina;
    public Animator animator;
    public Rigidbody rb;
    public bool canattack = true;
    public Movementcode movement;
    //bool Airattack;
    float delay;

    [SerializeField] private AttackState _currentAttackState = AttackState.NotAttacking;
    public AttackState CurrentAttackState => _currentAttackState;

    [SerializeField] private List<AttackMove> _attackMoves = new List<AttackMove>();

    private string _latestAttackName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canattack == false)
        {
            delay -= Time.deltaTime;
            if(delay <= 0)
            {
                canattack = true;
            }
        }
        if(movement.canmovecheck == true)
        {
            Attackcode();
        }
    }

   void Attackcode()
    {
        foreach (AttackMove move in _attackMoves)
        {
            if (Input.GetKeyDown(move.AttackKey)
                && (!move.ShouldCheckBlueStamina || stamina.currentbluestamina > 0)
                && (!move.ShouldCheckRedStamina || stamina.currentredstamina > 0)
                && (canattack || (move.PrevComboMoves.Contains(_latestAttackName) && _currentAttackState == AttackState.Recovering)))
            {
                if (!string.IsNullOrWhiteSpace(move.AnimTriggerName))
                {
                    animator.SetTrigger(move.AnimTriggerName);
                }
                stamina.currentbluestamina -= move.StaminaBlueCost;
                stamina.currentredstamina -= move.StaminaRedCost;

                delay = move.AttackDelay;
                canattack = false;
                _latestAttackName = move.MoveName;
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.Mouse0) == true )
        {
            animator.SetTrigger("N_atk02");
            stamina.currentredstamina -= 2;
            canattack = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            animator.SetTrigger("N_atk01");
            stamina.currentbluestamina -= 2;
            canattack = false;
        }
        if (Input.GetKeyDown(KeyCode.Q) == true && stamina.currentredstamina > 0)
        {
            print("LightAttack 1");
            stamina.currentredstamina -= 3;
            canattack = false;
        }
        if (Input.GetKeyDown(KeyCode.E) == true && stamina.currentbluestamina > 0)
        {
            print("HeavyAttack 1");
            stamina.currentbluestamina -= 3;
            canattack = false;
        }
        */
    }

    public enum AttackState
    {
        NotAttacking = 0,
        Attacking = 1,
        Recovering = 2,
    }
   
}
