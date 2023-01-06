using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerDetector : MonoBehaviour
{
    public float speed = 2f;
    
    // reference to Idle GameObject 
    [SerializeField] private GameObject idle;
    // reference to the player gameobject 
    GameObject player;

    // function to detect player within chase range 
    private void OnTriggerEnter2D(Collider2D other) {
        IdleState idleState = idle.GetComponent<IdleState>();
        if (other.CompareTag("Player")) {
            idleState.inChaseRange = true;
            player = other.transform.gameObject;
        }
    }

    // function to move enemy towards player if one is detected and if enemy is alive
    private void Update() {
        if (transform.parent.GetComponent<Enemy>().canMove) {
            if (player != null) {
                transform.parent.position = Vector2.MoveTowards(transform.parent.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
