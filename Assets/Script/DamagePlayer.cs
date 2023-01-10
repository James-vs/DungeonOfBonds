using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    // reference to the healthBar
    public GameObject healthBar;
    // audio sources
    public AudioSource heal;

    // reference to players animator
    Animator animator;

    // Start called before the first frame
    private void Start() {
        animator = transform.parent.GetComponent<Animator>();
    }

    // Check for collisions
    private void OnTriggerEnter2D(Collider2D other) {
        Slider slider = healthBar.GetComponent<Slider>();
        // if enemy touched player, and enemy not in death animation, damage player
        if (other.CompareTag("Enemy")) {
            Debug.Log("Enemy touched player");
            Enemy enemy = other.GetComponent<Enemy>();
            BossSlimeAIScript b = other.GetComponent<BossSlimeAIScript>();
            if (enemy != null && !enemy.isDefeated) {
                Debug.Log("Enemy damaged Player");
                InflictDamage(slider,enemy.damage);
            } else if (b != null && !b.isDefeated) {
                Debug.Log("Boss damaged player");
                InflictDamage(slider,b.damage);
            } else if (!other.GetComponent<BossScorpionAIScript>().isDefeated) {
                Debug.Log("Boss damaged player");
                BossScorpionAIScript s = other.GetComponent<BossScorpionAIScript>();
                InflictDamage(slider,s.damage);
            }
        } else if (other.CompareTag("Food")) {
            IncreaseHealth(slider, 100f);
            if (!heal.isPlaying) heal.Play();
        } else if (other.CompareTag("EnemyProjectile")) {
            InflictDamage(slider, other.GetComponent<ScorpionProjectile>().damage);
        }
    }

    // function to handle damaging the player and death animation
    private void InflictDamage (Slider slider, float damage) {
        slider.value -= damage;
        if (slider.value <= 0) {
            Debug.Log("Player Death");
            animator.SetTrigger("Death");
        }
    }

    // function to increase the health of the player by the value given
    // health can not go over 100
    private void IncreaseHealth(Slider slider, float value) {
        slider.value += value;
        if (slider.value > 100f) {
            slider.value = 100f;
        }
    }
}
