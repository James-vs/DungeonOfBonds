using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeAdded : MonoBehaviour
{
    // Start is called before the first frame update

    private bool pickup = false;
    private bool done = false;
    public GameObject parent;
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("f") && pickup && done == false){
            done = true;
            GameObject.Find("Player").GetComponent<TeamStatusController>().addToTeamByName(parent.name);
            Debug.Log("trying to add teammate");
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Player"){
            pickup = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        pickup = false;
    }
}
