using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bloc : MonoBehaviour
{
    protected int siblingIndex;
    public bool provientBanque = true;



    public abstract void executer(GameObject troupe);

    public abstract int GetSiblingIndex();

    

}
