using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class Vie : MonoBehaviour
{
    [SerializeField] private float vie;

    public Image barreDeVie;


    public Vie(float vie)
    {
        this.vie = vie;
    }


    public void Damage(float amount)
    {
        if (amount < 0) 
        {

            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }


        this.vie -= amount;
        barreDeVie.fillAmount = this.vie / 100;

        if(vie <= 0) 
        {
            Die();
        }
    }

    private void Die() 
    {
       // Debug.Log("I am Dead!");
       // Destroy(gameObject);
    
    
    }
    public float getLife() {

        return vie;
    
    }
        
}
