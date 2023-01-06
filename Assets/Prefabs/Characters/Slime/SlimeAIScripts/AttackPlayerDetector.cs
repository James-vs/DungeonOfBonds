using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerDetector : MonoBehaviour
{
    // reference to Idle GameObject 
    [SerializeField] private GameObject chase;

    // function to change enemy to attack state if player detected in range
    private void OnTriggerEnter2D(Collider2D other) {
        ChaseState chaseState = chase.GetComponent<ChaseState>();
        if (other.CompareTag("Player")) {
            chaseState.inAttackRange = true;
        }
    }
}
