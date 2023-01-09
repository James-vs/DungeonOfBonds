using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDungeon : MonoBehaviour
{
    public GameObject cantEnterDungeon;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            cantEnterDungeon.SetActive(false);
        }
    }
}
