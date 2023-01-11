using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyProjectile : MonoBehaviour
{

    public float damageToDeal = 0.0f;
    // audio sources
    public AudioSource enemyHit;

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("col");
        if(col.gameObject.tag == "Enemy"){
            Debug.Log("valid col");
            Enemy e = col.gameObject.GetComponent<Enemy>();
            BossSlimeAIScript b = col.gameObject.GetComponent<BossSlimeAIScript>();
            if (b == null && e == null) {
                BossScorpionAIScript s = col.gameObject.GetComponent<BossScorpionAIScript>();
                s.Health -= damageToDeal;
                s.damaged = true;
                enemyHit.Play();
            } else if (e == null) { // if enemy not a basic enemy
                b.Health -= damageToDeal;
                b.damaged = true;
                enemyHit.Play();
            } else {
                e.Health -= damageToDeal;
                enemyHit.Play();
            }
            Destroy(gameObject);
        }
    }

}
