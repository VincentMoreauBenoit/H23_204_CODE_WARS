using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjoutArray : MonoBehaviour
{
    public List<Bloc> blocs= new List<Bloc>();

    public void ajoutBloc(Bloc bloc)
    {
        blocs.Add(bloc);
    }
    public void jouer()
    {
        for(int i = 0;i < blocs.Count;i++)
        {
            blocs[i].executer(i);
        }
    }

}
