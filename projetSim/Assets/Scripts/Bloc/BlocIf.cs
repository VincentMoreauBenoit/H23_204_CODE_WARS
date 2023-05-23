using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Bloc permettant d'imposer une condition sur le code en dessous et le prochain fin si
public class BlocIf : Bloc
{
    [SerializeField] private TMP_Dropdown dropdownComparant;
    [SerializeField] private TMP_Dropdown dropCompare;
    [SerializeField] private TMP_Dropdown dropComparer;
    [SerializeField] private GameManager gameManager;

    public void Start()
    {
        siblingIndex= 3;
    }
    public override void executer(GameObject troupe)
    {
        int perso = dropdownComparant.value;
        int compare = dropCompare.value;
        int comparer = dropComparer.value;
        Condition condition;
        if(perso == 0){
            condition = new Condition(troupe,compare,comparer);
        }else{
            condition = new Condition(gameManager.getObjet(troupe.GetComponent<Personnage>().accederMemoire()),compare,comparer);
        }

        if(condition.verifier()){
            troupe.GetComponent<Personnage>().flip(true);
        }else{
            troupe.GetComponent<Personnage>().flip(false);
        }
    }

    public override int GetSiblingIndex()
    {
        return siblingIndex;
    }
}
