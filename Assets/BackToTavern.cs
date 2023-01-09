using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTavern : MonoBehaviour
{
    // variable for if the player split the money
    public bool splitCash = true;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (splitCash){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
    }
}
