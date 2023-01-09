using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // reference to food prefab
    [SerializeField] private GameObject food;
    // reference to spawn points
    private Vector3 spawn1;
    private Vector3 spawn2;
    public bool spawn1Empty = false;
    public bool spawn2Empty = false;

    public float spawn1Timer = 2f;
    public float spawn2Timer = 2f;

    // function called before the first frame
    private void Start() {
        spawn1 = new Vector2(1.1f,2.35f);
        spawn2 = new Vector2(-1.5f, 0f);
    }

    // using FixedUpdate to manage timers
    void FixedUpdate()
    {
        if (spawn1Empty) {
            spawn1Timer -= Time.deltaTime;
            if (spawn1Timer <= 0) {
                Instantiate(food, spawn1, transform.rotation);
            }
        }
    }
}
