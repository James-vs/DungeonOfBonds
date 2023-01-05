using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public float damage = 3f;
    Vector2 rightAttackOffset;
    public Collider2D swordCollider;

    private void Start() {
        rightAttackOffset = transform.position;
    }

    public void AttackRight(){
        Debug.Log("AttackRight called");
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft() {
        Debug.Log("AttackLeft called");
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Enemy enemy = other.GetComponent<Enemy>();
            Debug.Log("Enemy detected");

            if (enemy != null) {
                enemy.Health -= damage;
            }
        }
    }
}
