using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // audio sources
    public AudioSource slimeHit;


    public float damage = 3f;
    Vector2 rightAttackOffset;
    Collider2D swordCollider;


    private void Start() {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.localPosition;
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

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("collision detected");
        if (other.CompareTag("Enemy")) {
            Enemy enemy = other.GetComponent<Enemy>();
            BossSlimeAIScript b = other.GetComponent<BossSlimeAIScript>();
            BossScorpionAIScript s = other.GetComponent<BossScorpionAIScript>();
            Debug.Log("Enemy detected");

            if (enemy != null) {
                enemy.Health -= damage;
                if (!slimeHit.isPlaying) slimeHit.Play();
            } else if (b != null) {
                b.Health -= damage;
                b.damaged = true;
                if (!slimeHit.isPlaying) slimeHit.Play();
            } else if (s != null) {
                s.Health -= damage;
                s.damaged = true;
                if (!slimeHit.isPlaying) slimeHit.Play();
            }
        }
    }
}
