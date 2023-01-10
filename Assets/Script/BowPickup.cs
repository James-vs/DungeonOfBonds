using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BowPickup : MonoBehaviour
{
   float starty;

    public float floatStrength = 1;
    private bool pickup = false;
    private bool swordGotten = false;
    private GameObject hc;
    

    public TriggerToDialogue ttd;
    public string message;

    void Start()
    {
        this.starty = this.transform.position.y;
        pickup = false;
        ttd = GetComponent<TriggerToDialogue>();
        hc = GameObject.Find("HUDCanvas");
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            starty + ((float)Math.Sin(Time.time * 2) * floatStrength),
            transform.position.z);

        if(Input.GetKey("f") && pickup){
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            hc.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Objective:\nClick to fire! Kill that slime boss!";
            swordGotten = true;
            //ENABLE SWORD ATTACKS
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Player"){
            pickup = true;
            var boxToSpawn = ttd.dbox(message);
            Instantiate(boxToSpawn, col.gameObject.transform);
            hc.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Objective:\nPress F to pickup the bow";
            col.gameObject.transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
            col.gameObject.GetComponent<BowAttack>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        pickup = false;
        if(swordGotten){
            hc.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Objective:\nClick to fire! Kill that slime boss!";
        }
    }
}
