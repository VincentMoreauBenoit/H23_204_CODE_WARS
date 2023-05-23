using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


// Bloc permmetant de mettre en mémoire une troupe qu'on peut ensuite utiliser dans le bloc if
public class BlocVarTroupe : Bloc
{


    [SerializeField] private GameManager manager;
    private GameObject[] persoAllie;
    private GameObject[] persoEnnemi;
    private int indiceTotal;
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
        dropdown.AddOptions(option);
    }

    public override void executer(GameObject troupe)
    {
        indiceTotal = dropdown.value;
        TableauIndice indice = new TableauIndice();
        indice.convert(indiceTotal);
        troupe.GetComponent<Personnage>().setMemoire(indice);
    }

    public override int GetSiblingIndex()
    {
        return siblingIndex;
    }
}
