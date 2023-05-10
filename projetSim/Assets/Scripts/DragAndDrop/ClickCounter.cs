using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
