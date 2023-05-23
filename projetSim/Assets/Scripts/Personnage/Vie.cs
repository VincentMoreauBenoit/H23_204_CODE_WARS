using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class Vie : MonoBehaviour
{
    // Vie personnage
    [SerializeField] private float vie;
    // Image de la barre de vie
    public Image barreDeVie;

    /// <summary>
    /// Chaque personnage ont un vie qui leur 
    /// est propre
    /// </summary>
    /// <param name="vie">Vie des personnages</param>
    public Vie(float vie)
    {
        this.vie = vie;
    }

    /// <summary>
    /// Les personnges se font attaquer de montant d'attauque.Ce montant est ensuite
    /// soustrait à leur nombre de points de vie.
    /// </summary>
    /// <param name="amount">Le montant d'attaque </param>
    public void Damage(float amount)
    {
        if (amount < 0) 
        {
            // lance une exception si son montant d'attauqe est plus petit que 0. 
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }


        this.vie -= amount;
        barreDeVie.fillAmount = this.vie / 100;
    }

    /// <summary>
    /// Getter pour la vie
    /// </summary>
    /// <returns></returns>
    public float getLife() {

        return vie;
    
    }
        
}
