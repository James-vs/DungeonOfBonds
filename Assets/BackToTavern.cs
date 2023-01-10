using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTavern : MonoBehaviour
{
    // variable for if the player split the money
    public bool splitCash;
    

    private void Start() {
        splitCash = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (splitCash){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
            }
        }
    }

    public void SplitCash() {
        splitCash = true;
        //chestScreen.SetActive(false);
        Debug.Log("split");
    }

    public void NoSplitCash() {
        splitCash = false;
        //chestScreen.SetActive(false);
        Debug.Log("no split");
    }
}
