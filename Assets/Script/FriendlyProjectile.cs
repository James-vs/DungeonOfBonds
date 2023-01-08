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
            e.Health -= damageToDeal;
            Destroy(gameObject);
        }
    }

}
