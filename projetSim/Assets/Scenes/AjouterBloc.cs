using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
//using UnityEngine.UIElements;

public class AjouterBloc : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform rTransform;
    public TMP_Dropdown dropdown;
    
    public void Ajouter()
    {
        var positionInitiale = rTransform.localPosition;
        var positionFinale = new Vector3(rTransform.localPosition.x, rTransform.localPosition.y - 40, rTransform.localPosition.z);
        rTransform.localPosition = positionFinale;

        dropdown.transform.SetParent(canvas.transform, false);
        dropdown.transform.localPosition = positionInitiale;
        

      

    }
}

