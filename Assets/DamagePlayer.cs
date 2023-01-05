using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    // reference to the healthBar
    public GameObject healthBar;
    // reference to players animator
    Animator animator;

    // Start called before the first frame
    private void Start() {
        animator = transform.parent.GetComponent<Animator>();
    }

    // Check for collisions
    private void OnTriggerEnter2D(Collider2D other) {
        // if enemy touched player, and enemy not in death animation, damage player
        if (other.CompareTag("Enemy")) {
            Debug.Log("Enemy touched player");
            if (!other.GetComponent<Enemy>().isDefeated) {
                Debug.Log("Enemy damaged Player");
                Enemy enemy = other.GetComponent<Enemy>();
                Slider slider = healthBar.GetComponent<Slider>();
                InflictDamage(slider,enemy.damage);
            }
        }
    }

    // function to handle damaging the player and death animation
    private void InflictDamage (Slider slider, float damage) {
        slider.value -= damage;
        if (slider.value <= 0) {
            Debug.Log("Player Death");
            animator.SetTrigger("Death");

            //need to do some other stuff
        }
    }
}
