using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocIf : Bloc
{


    public void Start()
    {
        siblingIndex= 3;
    }
    public override void executer(GameObject troupe)
    {
        Debug.Log("Bloc if");
    }

    public override int GetSiblingIndex()
    {
        return siblingIndex;
    }
}
