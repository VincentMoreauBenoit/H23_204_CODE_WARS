using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocVarTroupe : BlocVar
{

    public override void executer(GameObject troupe)
    {
        Debug.Log("Mémoire");
    }

    public override int GetSiblingIndex()
    {
        throw new System.NotImplementedException();
    }
}
