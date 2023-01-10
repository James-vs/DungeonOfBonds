using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AICombatController : MonoBehaviour
{
    SwordAttack sa;
    AIPath aip;

    // Start is called before the first frame update
    void Start()
    {
        sa = GetComponent<SwordAttack>();
        aip = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        aip.endReachedDistance = 0.22f;
        GameObject go = FindClosestEnemy();
        AIDestinationSetter aids = GetComponent<AIDestinationSetter>();
        if (go != null){
            aids.target = go.transform;
            //none of this is necessary he just kills everything he touches for some reason lmao
            /* if (aip.reachedEndOfPath){
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                Debug.Log("attack command");
                if(rb.velocity.x >= 0){
                    //sa.AttackRight();
                }else{
                    //sa.AttackLeft();
                }
            } */
        }else{
            aip.endReachedDistance = 0.5f;
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Player");
            GameObject player = gos[0];
            aids.target = player.transform;
        }
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


}
