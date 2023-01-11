using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneySplit : MonoBehaviour
{
    public void cSplit(){
        var btt = GameObject.Find("BackToTavern").GetComponent<BackToTavern>();
        btt.splitCash = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //exit();
    }

    public void cNoSplit(){
        var btt = GameObject.Find("BackToTavern").GetComponent<BackToTavern>();
        btt.splitCash = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        //exit();
    }
    

    public void exit() {
        var chest = GameObject.Find("Studded_Wooden_Chest");
        chest.GetComponent<Clicker>().exit();
        chest.SetActive(false);
        var chestG = GameObject.Find("ChestGlow");
        chestG.SetActive(false);   
        gameObject.SetActive(false);
    }
}
