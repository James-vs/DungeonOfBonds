using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public bool isDefeated = false;
    public float Health {
        set {
            health = value;
            Debug.Log("enemy health" + health);
            if (health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float chaseSpeed = 0.3f;

    public float damage = 20f;

    public float health = 1f;

    public bool canMove = true;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void Defeated() {
        animator.SetTrigger("Defeated");
        isDefeated = true;
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    public void LockMovement() {
        // lock movement while attacking
        canMove = false;
    }

    // function to make the enemy move towards the player
    public void ChasePlayer(GameObject player) {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
    }

}
