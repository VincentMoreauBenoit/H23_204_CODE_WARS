using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

//Permets de transfomer un indice unique en deux en fonction du nombre d'objet dans les deux tableaux
public class TableauIndice : MonoBehaviour
{
    private GameManager gameManager;
    private int indice;
    private int tableau;
    private int nbAllie;
    private int nbEnnemi;

    void Start()
    {
        nbAllie = gameManager.getPersoAllie().Length;
        nbEnnemi = gameManager.getPersoEnnemi().Length;
    }
    public int getTab()
    {
        return tableau;
    }

    public int getIndice() 
    { 
        return indice; 
    }
    //Converti entre les deux types d'indice
    public void convert(int indiceTotal)
    {
        if (indiceTotal <= nbAllie - 1)
        {
            tableau = 0;
            indice = indiceTotal;
        }
    }
}
