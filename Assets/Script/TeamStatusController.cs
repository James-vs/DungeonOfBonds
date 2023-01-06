using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamStatusController : MonoBehaviour
{

    public List<GameObject> teamMates;
    public GameObject hudcanvas;
    public GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        teamMates = new List<GameObject>();
        hudcanvas = GameObject.Find("HUDCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        //update health bars   
    }

    public void addToTeamByName(string name){
        GameObject tm = GameObject.Find(name);
        if (tm.GetComponent<AITeammateData>().onTheTeam == true){
            teamMates.Add(tm);
            Instantiate(test, hudcanvas.transform);

            //add a ui piece
            //record health bar
            //subtract 100 from y transform per number of existing teammates
        }
    }

    
}
