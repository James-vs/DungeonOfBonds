using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForD1C : MonoBehaviour
{
    public GameObject d1CBlocker;
    public GameObject dungeon1Complete;
    public GameObject bossBattleWall;
    public GameObject backWall;
    public GameObject chest;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            // activate switch 
            // enable D1C 
            // disable D1C blocker
            // disable bossBattleWall
            // disable backWall
            // enable chest
            d1CBlocker.SetActive(false);
            dungeon1Complete.SetActive(true);
            bossBattleWall.SetActive(false);
            backWall.SetActive(false);
            chest.SetActive(true);
        }
    }
}
