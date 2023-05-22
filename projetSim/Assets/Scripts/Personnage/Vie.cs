using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Vie : MonoBehaviour
{
    [SerializeField] private int vie;

    public Vie(int vie)
    {
        this.vie = vie;
    }

    public void Damage(int amount)
    {
        if (amount < 0) 
        {

            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }


        this.vie -= amount;        

        if(vie <= 0) 
        {
            Die();
        }
    }

    private void Die() 
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    
    
    }
    public int getVie(){
        return vie;
    }
        
}
