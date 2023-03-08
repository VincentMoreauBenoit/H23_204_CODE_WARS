using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlocBouger : Bloc
{

    public Direction direction = Direction.AVANT;
    public TMP_Dropdown dropdown;

    public BlocBouger(TMP_Dropdown dropdown)
    {
        this.dropdown = dropdown;
        dropdown.onValueChanged.AddListener(delegate
        {
            changer();
        });
       
        
        
    }
    public void changer()
    {
        setDirection(dropdown.captionText.text);
    }

    override
    public void executer(int i)
    {
        Debug.Log(direction.ToString());
    }
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
}
