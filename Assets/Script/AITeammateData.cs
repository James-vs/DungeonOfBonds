using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITeammateData : MonoBehaviour
{
    public float health;
    public string myName;
    public bool onTheTeam;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;    
    }
}
