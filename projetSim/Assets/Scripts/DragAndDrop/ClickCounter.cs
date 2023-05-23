using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Compte le nombre de clique entrer puis détruit le pane du UI utiliser pour affcieher les messages textes du jeu
public class ClickCounter : MonoBehaviour
{
    [SerializeField] private int nbClique;
    [SerializeField] private Button bouton;

    public void cliquer()
    {
        if(nbClique>1) {
            nbClique--;
        }
        else {
            Destroy(gameObject);
        }
        
        
    }

    
}
