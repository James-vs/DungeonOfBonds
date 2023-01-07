using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TeamStatusController : MonoBehaviour
{

    public List<GameObject> teamMates;
    public GameObject[] aiSet;
    public GameObject hudcanvas;
    public GameObject aiUI;
    public Dictionary<String, GameObject> nameToUIPiece;
    private int uiCount;
    // Start is called before the first frame update
    void Start()
    {
        uiCount = 0;
        hudcanvas = GameObject.Find("HUDCanvas");
        nameToUIPiece = new Dictionary<String, GameObject>();

        //add all teammates back to the tracker
        teamMates = new List<GameObject>();
        aiSet = GameObject.FindGameObjectsWithTag("AI");
        foreach (GameObject ai in aiSet){
            AITeammateData aitd = ai.GetComponent<AITeammateData>();
            if(aitd.onTheTeam){
                addToTeamByName(ai.name);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //for testing
        if (Input.GetKeyUp(KeyCode.X))
        {
            foreach (GameObject ai in aiSet){
            AITeammateData aitd = ai.GetComponent<AITeammateData>();
            aitd.onTheTeam = true;
            addToTeamByName(ai.name);}
        }

        foreach (GameObject tm in teamMates){
            AITeammateData aitd = tm.GetComponent<AITeammateData>();
            GameObject uip;
            if(nameToUIPiece.TryGetValue(tm.name, out uip))
            {
                GameObject healthBar = uip.transform.GetChild(0).gameObject;
                Slider slider = healthBar.GetComponent<Slider>();
                slider.value = aitd.health;
            }
        }

        //update health bars   
    }

    public void addToTeamByName(string name){
        GameObject tm = GameObject.Find(name);
        if (tm.GetComponent<AITeammateData>().onTheTeam == true){
            teamMates.Add(tm);
            GameObject newAiUI = Instantiate(aiUI, hudcanvas.transform);
            nameToUIPiece.Add(name, newAiUI);
            Vector3 pos = newAiUI.transform.position;   //NEEDS TESTING
            newAiUI.transform.position = new Vector3(pos.x, pos.y - 100 * uiCount, pos.z); 
            GameObject nameText = newAiUI.transform.GetChild(1).gameObject;
            nameText.GetComponent<TextMeshProUGUI>().text = name;
            uiCount +=1;
            //add a ui piece
            //record health bar
            //subtract 100 from y transform per number of existing teammates
        }
    }

    
}
