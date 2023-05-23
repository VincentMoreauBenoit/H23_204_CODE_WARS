using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe pour récupérer et exécuter le code afficher à l'écran
public abstract class Bloc : MonoBehaviour
{
    protected int siblingIndex;
    public bool provientBanque = true;



    public abstract void executer(GameObject troupe);

    //Méthode pour placer le bloc à la bonne position dans la barre de bloc
    public abstract int GetSiblingIndex();

    

}
