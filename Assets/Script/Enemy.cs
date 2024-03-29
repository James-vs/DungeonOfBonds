using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource death;
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

    public float damage = 20f;

    public float health = 1f;

    public bool canMove = true;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void Defeated() {
        animator.SetTrigger("Defeated");
        isDefeated = true;
        death.Play();
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    public void LockMovement() {
        // lock movement while attacking
        canMove = false;
    }

}
