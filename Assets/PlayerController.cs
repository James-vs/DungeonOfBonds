using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
    
    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Physics controls 
    private void FixedUpdate() {
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
            Debug.Log("IsMoving: True");
        } else if (movementInput.x > 0) {
            spriteRenderer.flipX = false;
            Debug.Log("IsMoving: False");
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
}