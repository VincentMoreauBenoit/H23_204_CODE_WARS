using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountHellos : MonoBehaviour
{
    public int health = 5;
    public TMP_Text healthText;

    void Start()
    {
        health = 5;
        healthText.text = "HEALTH : " + health;
    }

    void Update()
    {
        healthText.text = "HEALTH : " + health;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }

}
