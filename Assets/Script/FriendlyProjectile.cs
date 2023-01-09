using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyProjectile : MonoBehaviour
{

    public float damageToDeal = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            } else if (e == null) { // if enemy not a basic enemy
                b.Health -= damageToDeal;
                b.damaged = true;
            } else {
                e.Health -= damageToDeal;
            }
            Destroy(gameObject);
        }
    }

}
