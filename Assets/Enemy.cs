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

    public float damage = 20f;

    public float health = 1f;

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
}
