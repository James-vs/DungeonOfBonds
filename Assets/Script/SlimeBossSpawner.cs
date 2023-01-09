using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBossSpawner : MonoBehaviour
{
    // reference to the boss slime gameObject
    public GameObject bossSlime;

    // if player hits this trigger, spawn in the slime boss and disable this trigger 
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            bossSlime.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
