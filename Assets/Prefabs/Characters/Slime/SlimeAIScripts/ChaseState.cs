using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    // AttackState variable for switch 
    public AttackState attackState;
    // bool for if player in attack range 
    public bool inAttackRange;

    // reference to sprite animator
    Animator animator;

    // using start method to get enemy animator component 
    private void Start() {
        animator = transform.parent.parent.GetComponent<Animator>();
    }

    // override function to return attack state if player in range 
    public override State RunCurrentState() {
        if (inAttackRange) {
                // if player is inChaseRange, change animation and state
                animator.SetTrigger("Attack");
                return attackState;
        } else {
            return this;
        }
    }
}
