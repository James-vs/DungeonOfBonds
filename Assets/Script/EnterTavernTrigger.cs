using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterTavernTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public TriggerToDialogue ttd;
    public string message;
    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        ttd = GetComponent<TriggerToDialogue>();
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Player" && triggered == false){
            var boxToSpawn = ttd.dbox(message);
            Instantiate(boxToSpawn, GameObject.Find("Commoner").transform);
            triggered = true;
            var hc = GameObject.Find("HUDCanvas");
            hc.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Objective:\nPress F near Jonton to recruit him to your team";
        }

    }
}
