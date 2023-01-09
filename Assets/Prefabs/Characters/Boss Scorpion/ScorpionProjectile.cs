using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionProjectile : MonoBehaviour
{
    public float speed = 2f;

    public float damage = 10f;

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start() {
        //get the player object from the scene and it's coordinates
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y) {
            DestroyProjectile();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            DestroyProjectile();
        }
    }

    void DestroyProjectile() {
        Destroy(gameObject);
    }

}
