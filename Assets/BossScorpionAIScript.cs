using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class BossScorpionAIScript : MonoBehaviour
{

    public Transform target;
    public float speed = 300f;
    public float nextWaypointDistance = 3f;
    public GameObject slime;
    public bool isDefeated = false;
    public float damage = 30f;
    public bool damaged = false;
    public GameObject switchWall;
    
    float timer = 1f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    bool canMove = true;

    Seeker seeker;
    Rigidbody2D rb;

    Animator animator;

    public float Health {
        set {
            health = value;
            Debug.Log("boss health " + health);
            if (health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }
    
    public float health = 1f;
    

    // Start is called before the first frame update
    void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);

    }    

    // function to update the path to the target 
    void UpdatePath() {
        if (seeker.IsDone() && canMove == true) {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    // function to handle enemy reaching its destination
    void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    
    // function to handle movement and physics
    private void FixedUpdate() {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count) {
            reachedEndOfPath = true;
            return;
        } else {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }

        // spawn a slime every 3 seconds
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            Instantiate(slime, rb.position, transform.rotation);
            timer = 1f;
        }

        if (damaged == true) {
            animator.SetBool("Damaged", true);
        }
    }

    // function to trigger defeated animation    
    public void Defeated() {
        animator.SetTrigger("Defeated");
        isDefeated = true;
    }

    // function to destroy enemy and unblock next level switch 
    public void RemoveEnemy() {
        if (switchWall != null) switchWall.SetActive(false);
        Destroy(gameObject);
    }

    // function to lock enemy movement
    public void LockMovement() {
        // lock movement while attacking
        canMove = false;
    }

    // function to change enemy back to idle state after being damaged
    public void DamagedEnd() {
        damaged = false;
        animator.SetBool("Damaged", false);
    }
}

