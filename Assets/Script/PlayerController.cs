using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
    public SwordAttack swordAttack;
    public bool dungeonEnabled;
    public bool bowUnlocked;
    
    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    BowAttack ba;
    
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    public AudioSource playerWalk;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dungeonEnabled = false;
        ba = GetComponent<BowAttack>();
        if(ba != null){
            if(ba.enabled == false){
                bowUnlocked = false;
            }else{
               bowUnlocked = true;
            }
            ba.enabled = false; 
        }
    }

    // Physics controls 
    private void FixedUpdate() {
        // if player not attacking
        if (canMove) {
            // if the movement vector isnt 0, move player
            if (movementInput != Vector2.zero) {
                bool success = TryMove(movementInput);
                // if movement unsuccessful in both directions, try x and y individually
                if (!success) {
                    success = TryMove(new Vector2(movementInput.x,0)); 

                    if (!success) {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }

                animator.SetBool("IsMoving", success);
            } else {
                animator.SetBool("IsMoving", false);
            }

            // Set direction of sprite to movement direction 
            if (movementInput.x < 0) {
                spriteRenderer.flipX = true;
                //Debug.Log("IsMoving: True");
            } else if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
                //Debug.Log("IsMoving: False");
            }
        }

        if (Input.GetKey("1")){
            swordAttack.enabled = true;
            if(ba != null){
                ba.enabled = false;
            }
        }

        if (Input.GetKey("2")){
            swordAttack.enabled = false;
            if(ba != null && bowUnlocked){
                ba.enabled = true;
            }else{
                swordAttack.enabled = true;
            }
        }
    }

    private bool TryMove(Vector2 direction) {
        if (direction != Vector2.zero) {
            // Cast return number of possible collisions in area player is trying to move into before it moves
            int count = rb.Cast(    
                direction, // x and y values between 1 and -1 that represent the direction from the body to look from collisions 
                movementFilter, // the settings that determine where a collision can occur on such as layers to collide with 
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset // the amount to cast equal to the movement plus an offset 
            );

            if (count == 0) {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                if (!playerWalk.isPlaying) playerWalk.Play();
                return true;
            } else {
                return false;
            }
        } else {
            // Can't move if there's no direction to move in
            return false;
        }

    }

    // Movement Controls
    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire() {
        print("Fire pressed");
        if (swordAttack.enabled == true){
            animator.SetTrigger("SwordAttack");
        }
    }

    public void SwordAttack() {
        LockMovement();
        if (spriteRenderer.flipX == true) {
            swordAttack.AttackLeft();
        } else {
            swordAttack.AttackRight();
        }
    }

    public void EndSwordAttack() {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement() {
        // lock movement while attacking
        canMove = false;
    }

    public void UnlockMovement() {
        // unlock movement after attacking
        canMove = true;
    }

    // function to respawn character (restart the level)
    public void Respawn () {
        //Instantiate(this.gameObject, new Vector3(0,0,0), transform.rotation);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // function to chenge scene to dungeon scene 
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("DungeonEntrance")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if (other.CompareTag("Food")) {
           dungeonEnabled = true;
        } else if (other.CompareTag("EndScreen")) { // if player finishes game and tried to do back in dungeon
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }
    }

}
