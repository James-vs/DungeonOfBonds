using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCanvas : MonoBehaviour
{
    public GameObject healthbar;
    public GameObject coinsView;
    public GameObject currentObjective;
    public GameObject moneySplit;

    public void onClick() {
        Debug.Log("Click detected");
        moneySplit.SetActive(false);
        healthbar.SetActive(true);
        coinsView.SetActive(true);
        currentObjective.SetActive(true);
        Time.timeScale = 1f;
    }
}
