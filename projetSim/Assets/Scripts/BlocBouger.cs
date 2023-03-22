using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

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
        Debug.Log("Changer");
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
        Debug.Log(direction.ToString());
    }
}
