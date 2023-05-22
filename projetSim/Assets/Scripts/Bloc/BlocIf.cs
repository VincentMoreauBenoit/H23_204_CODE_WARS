using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlocIf : Bloc
{
    [SerializeField] private TMP_Dropdown dropdownComparant;
    [SerializeField] private TMP_Dropdown dropCompare;
    [SerializeField] private TMP_Dropdown dropComparer;

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
