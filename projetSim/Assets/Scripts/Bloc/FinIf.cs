using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Permets de finir la condition if pour tous les blocs affecter par celle-ci
public class FinIf : Bloc
{
    public void Start()
    {
        siblingIndex= 4;
    }

    
    public override void executer(GameObject troupe)
    {
       troupe.GetComponent<Personnage>().flip(true);
    }

    public override int GetSiblingIndex()
    {
        return siblingIndex;
    }
}
