using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class BlocVarTroupe : Bloc
{


    [SerializeField] private GameManager manager;
    private GameObject[] persoAllie;
    private GameObject[] persoEnnemi;
    [SerializeField] private TMP_Dropdown dropdown;
    private List<string> option;

    void Start()
    {
        siblingIndex = 2;
        persoAllie = manager.getPersoAllie();
        persoEnnemi = manager.getPersoEnnemi();
        option = new List<string>();
        for(int i =0;i<persoAllie.Length;i++){
            option.Add("Allie #"+i);
        }
        for(int i = 0; i<persoEnnemi.Length;i++){
            option.Add("Ennemi #"+i);
        }
    }

    public override void executer(GameObject troupe)
    {
        Debug.Log("Mémoire");
    }

    public override int GetSiblingIndex()
    {
        return siblingIndex;
    }
}
