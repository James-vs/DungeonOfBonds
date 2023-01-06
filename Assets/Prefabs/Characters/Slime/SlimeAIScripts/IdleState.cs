using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    // ChaseState variable for switch 
    public ChaseState chaseState;
    // bool for if enemy can see player 
    public bool inChaseRange;

    // reference to sprite animator
    Animator animator;

    // using start method to get enemy animator component 
    private void Start() {
        animator = transform.parent.parent.GetComponent<Animator>();
    }

    // override function to return chase state if player in range 
    public override State RunCurrentState()
    {
        if (inChaseRange) {
            // if player is inChaseRange, change animation and state
            animator.SetTrigger("Chase");
            return chaseState;
        } else {
            return this;
        }
    }
}
