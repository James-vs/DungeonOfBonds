using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pathfinding;

public class LeavesYouTrigger : MonoBehaviour
{
   public TriggerToDialogue ttd;
    public string message;
    private bool triggered = false;
    public GameObject talker;
    public float timeSinceTrigger;
    public PlayerController playerC;
    public GameObject jt;
    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        ttd = GetComponent<TriggerToDialogue>();
        triggered = false;
        timeSinceTrigger = 0f;
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        jt = GameObject.Find("Jonton");

    }

    // Update is called once per frame
    void Update()
    {
        if (!done){
            if(triggered){
                timeSinceTrigger += Time.deltaTime;
            }

            if(timeSinceTrigger > 1f && timeSinceTrigger < 3.9f){
                jt.GetComponent<Rigidbody2D>().velocity = new Vector3(1.2f, 0f, 0f);
            }

            if(timeSinceTrigger > 4f){
                playerC.UnlockMovement();
                jt.SetActive(false);
                done = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Player" && triggered == false){
            col.gameObject.GetComponent<PlayerController>().LockMovement();
            var boxToSpawn = ttd.dbox(message);
            Instantiate(boxToSpawn, talker.transform);
            triggered = true;
            jt.transform.position = new Vector3(6.11000013f ,7.3499999f,0f);
            jt.GetComponent<AIPath>().enabled = false;
            jt.GetComponent<AIDestinationSetter>().enabled = false;
            jt.GetComponent<AICombatController>().enabled = false;
        }

    }
}
