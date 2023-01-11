using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySplit : MonoBehaviour
{
    public void cSplit(){
        var btt = GameObject.Find("BackToTavern").GetComponent<BackToTavern>();
        btt.splitCash = true;
        exit();
    }

    public void cNoSplit(){
        var btt = GameObject.Find("BackToTavern").GetComponent<BackToTavern>();
        btt.splitCash = false;
        exit();
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
