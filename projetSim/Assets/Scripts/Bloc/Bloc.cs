using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bloc : MonoBehaviour
{
    public int siblingIndex;
    public bool provientBanque = true;


    public abstract void executer(GameObject troupe);

    public abstract int GetSiblingIndex();

    

}
