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
        
    }

    public override int GetSiblingIndex()
    {
        return siblingIndex;
    }
}
