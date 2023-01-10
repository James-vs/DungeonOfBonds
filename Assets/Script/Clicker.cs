using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    // Money Choice Canvas
    public GameObject moneyChoice;
    //public GameObject player;
    public GameObject healthBar;
    public GameObject coinsView;
    public GameObject currentObjective;

    // method to allow player to click the chest for the rewards screen
    private void OnMouseDown() {
        moneyChoice.SetActive(true);
        //player.SetActive(false);
        healthBar.SetActive(false);
        coinsView.SetActive(false);
        currentObjective.SetActive(false);
        Time.timeScale = 0f;
    }
}

