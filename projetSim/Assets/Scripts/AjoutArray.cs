using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjoutArray : MonoBehaviour
{
    public List<Bloc> blocs= new List<Bloc>();
    public void jouer()
    {
        blocs = Ligne.CreerListeBloc();
        for(int i = 0;i < blocs.Count;i++)
        {
            GameObject objet = null;
            blocs[i].executer(objet);
        }
    }

}
