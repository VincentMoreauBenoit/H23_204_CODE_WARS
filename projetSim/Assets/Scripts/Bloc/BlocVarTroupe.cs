using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocVarTroupe : Bloc
{

    void Start()
    {
        siblingIndex = 2;
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
