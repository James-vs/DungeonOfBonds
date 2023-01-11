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
    public GameObject bossBattleWall;
    public AudioSource chestClick;

    // method to allow player to click the chest for the rewards screen
    private void OnMouseDown() {
        if (!chestClick.isPlaying) chestClick.Play();
        moneyChoice.SetActive(true);
        //player.SetActive(false);
        healthBar.SetActive(false);
        coinsView.SetActive(false);
        currentObjective.SetActive(false);
        bossBattleWall.SetActive(false);
        //Time.timeScale = 0f;
    }

    public void exit() {
        Debug.Log("Click detected");
        healthBar.SetActive(true);
        coinsView.SetActive(true);
        currentObjective.SetActive(true);
        //Time.timeScale = 1f;
    }
}

