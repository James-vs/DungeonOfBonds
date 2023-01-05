using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDemo : MonoBehaviour
{

    [SerializeField] private float health; //del
    public Slider healthSlider;
    public Gradient healthGrad;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f; //del
    }

    // Update is called once per frame
    void Update()
    {
        health -= 0.1f; //del
        healthSlider.value = health; //change to actual health
        healthBar.color = healthGrad.Evaluate(healthSlider.normalizedValue);
    }
}
