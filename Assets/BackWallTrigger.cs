using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWallTrigger : MonoBehaviour
{

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
            Instantiate(boxToSpawn, col.gameObject.transform);
            triggered = true;
        }

    }
}
