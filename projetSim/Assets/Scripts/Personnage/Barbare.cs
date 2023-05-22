using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbare : Personnage
{
    private bool premierePhase = true;
    private bool deuxiemePhase = true;


    public Barbare() : base(7, 6, 7) 
    { 
    }


    public override void attaque() 
    {

        // L'attaque de base du barbare est de 7(zeroieme phase).

        // Quand ces points de vies descendent jusqu'a 69 mais restent au-dessus de 30, son attaque de base est doubler(14 point d'attaque : première phase)
        if (premierePhase)
        {
            if (this.getVie() < 70 && this.getVie() > 30)
            {
                this.setDommage(this.getDommage() * 2);
                premierePhase = false;
            }
        }

        // Quand ces point de vies descendent en-dessous de 30, son attaque est encore doubler.(28 point d'attaque : deuxième phase)
        // ** Si il descend tout de suite en dessous de 30 sans passer par la première phrase, son attaque sera quand même de 28.  
        if (deuxiemePhase)
        {
            if (this.getVie() < 30)
            {
                if(this.getDommage() != (this.getDommage() * 2))
                {
                    this.setDommage(this.getDommage() * 2);
                }

                this.setDommage(this.getDommage() * 2);
                deuxiemePhase = false;
            }
        }

        //L'attaque de base de la classe personnage 
        base.attaque();

    }
}


