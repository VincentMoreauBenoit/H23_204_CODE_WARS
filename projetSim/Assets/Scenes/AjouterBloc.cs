using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AjouterBloc : MonoBehaviour
{
    public Canvas canvas;
    public GameObject content;
    public RectTransform rTransform;
    public TMP_Dropdown dropdown;
    public AjoutArray ajoutBlocs; 

    public void AjouterBouger()
    {
        var positionInitiale = rTransform.localPosition;
        positionInitiale.x += 40;
        var positionFinale = new Vector3(rTransform.localPosition.x, rTransform.localPosition.y - 40, rTransform.localPosition.z);
        rTransform.localPosition = positionFinale;

        var drop = Instantiate(dropdown);
        drop.transform.SetParent(content.transform, false);
        drop.transform.localPosition = positionInitiale;
        BlocBouger blocBouger = new BlocBouger(drop);
        ajoutBlocs.ajoutBloc(blocBouger);
    }
    
}

