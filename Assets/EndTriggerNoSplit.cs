using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pathfinding;
using UnityEngine.SceneManagement;

public class EndTriggerNoSplit : MonoBehaviour
{
   public TriggerToDialogue ttd;
    private bool triggered = false;
    public GameObject talker;
    public float timeSinceTrigger;
    public PlayerController playerC;
    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        ttd = GetComponent<TriggerToDialogue>();
        triggered = false;
        timeSinceTrigger = 0f;
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
            if(triggered){
                timeSinceTrigger += Time.deltaTime;
            }


            if(timeSinceTrigger > 5f && done == false){
                done = true;
                var boxToSpawn = ttd.dbox("No matter your apparent stinginess, you're always welcome in our tavern!");
                Instantiate(boxToSpawn, talker.transform);
            }
            if(timeSinceTrigger > 10f){
                SceneManager.LoadScene(9);
            }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Player" && triggered == false){
            col.gameObject.GetComponent<PlayerController>().LockMovement();
            triggered = true;
            var boxToSpawn = ttd.dbox("Thanks for helping keep our town safe traveller! Shame you and Jonton can't see eye to eye");
            Instantiate(boxToSpawn, talker.transform);
        }

    }
}
