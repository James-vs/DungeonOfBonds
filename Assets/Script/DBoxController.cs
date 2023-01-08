using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBoxController : MonoBehaviour
{

    public float lifeSpan = 3.0f;
    private float timeOnScreen = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeOnScreen = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeOnScreen += Time.deltaTime;
        if (timeOnScreen > lifeSpan){
            gameObject.SetActive(false);
        }
    }
}
