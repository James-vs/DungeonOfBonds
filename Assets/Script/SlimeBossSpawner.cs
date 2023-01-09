using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBossSpawner : MonoBehaviour
{
    // reference to the boss slime gameObject
    public GameObject bossSlime;
    public GameObject battleWall;

    // if player hits this trigger, spawn in the slime boss,
    // disable this trigger and enable the battle wall 
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            bossSlime.SetActive(true);
            gameObject.SetActive(false);
            battleWall.SetActive(true);
        }
    }
}
