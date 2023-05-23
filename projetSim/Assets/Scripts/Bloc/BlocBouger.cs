using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


//Bloc permettant au bloc de bouger sur la carte
public class BlocBouger : Bloc
{
    [SerializeField] Direction direction = Direction.AVANT;
    [SerializeField] TMP_Dropdown dropdown;

    public void Start()
    {
        siblingIndex = 0;
    }


    public void changer()
    {
        setDirection(dropdown.captionText.text);
    }

    override
    public void executer(GameObject troupe)
    {
        if (troupe.GetComponent<Personnage>() != null)
        {
            Personnage perso = troupe.GetComponent<Personnage>();
            perso.setDirection(direction);
            perso.resetTimer();
        }

    }
    //Permets de changer la direction qund l'utilisateur change celle-ci
    public void setDirection(string direct)
    {
        
        if(direct == "Avant") 
        {
            direction = Direction.AVANT;
        }
        else if(direct == "Gauche")
        {
            direction = Direction.GAUCHE;
        }else if(direct == "Droite")
        {
            direction = Direction.DROITE;
        }
        else
        {
            direction = Direction.ARRIERE;
        }
        
    }

    public override int GetSiblingIndex()
    {
        return siblingIndex;
    }
}
