using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bloc permettant au troupe d'attaquer
public class BlocAttaque : Bloc
{
    public Personnage personnage;

    override
    public void executer(GameObject troupe)
    {
        troupe.GetComponent<Personnage>().attaque();

    }

    public override int GetSiblingIndex()
    {
        return siblingIndex;
    }

    public void Start()
    {
        siblingIndex = 1;
    }
}
