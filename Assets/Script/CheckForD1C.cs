using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForD1C : MonoBehaviour
{
    public GameObject d1CBlocker;
    public GameObject dungeon1Complete;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            // activate switch 
            // enable D1C 
            // disable D1C blocker
            d1CBlocker.SetActive(false);
            dungeon1Complete.SetActive(true);
        }
    }
}
