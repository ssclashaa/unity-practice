using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarScript : MonoBehaviour {

    float health = 100;
    
    Slider _slider;

    // Use this for initialization
    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        health -= 1f;

        if (health <= 0)
        {
            Debug.Log("Death");
        }

        _slider.value = health;
    }
}
