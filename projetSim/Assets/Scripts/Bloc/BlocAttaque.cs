using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocAttaque : Bloc
{
    public override void executer(GameObject troupe)
    {
        Debug.Log("Attaque");
    }

    public override int GetSiblingIndex()
    {
        return siblingIndex;
    }

    public void Start()
    {
        siblingIndex = 1;
    }
}
