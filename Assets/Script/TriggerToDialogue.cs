using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerToDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject toSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject dbox(string text){
        var newGO = toSpawn;
        newGO.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        return newGO;
    }
}
