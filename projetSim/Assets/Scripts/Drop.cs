using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    private RectTransform rectTransform;
    [SerializeField] private GameObject prefabLine;
    [SerializeField] private GameObject content;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData){
        GameObject dropped = eventData.pointerDrag;
        DragDrop drag = dropped.GetComponent<DragDrop>();
        drag.parentAfterDrag = rectTransform;

        if(eventData.pointerDrag != null) { 
            eventData.pointerDrag.GetComponent<RectTransform>().localPosition = GetComponent<RectTransform>().localPosition;
        }

        var ligne2 = Instantiate(prefabLine);
        var rect = ligne2.GetComponent<RectTransform>();
        var rectCont = content.GetComponent<RectTransform>();
        rect.SetParent(rectCont);
        rect.localPosition = GetComponent<RectTransform>().localPosition;
        Vector3 temp = rect.localScale;
        temp.x /= temp.x; 
        temp.y /= temp.y; 
        temp.z /= temp.z;
        rect.localScale = temp;
        
        Ligne.verifLineHaut();
    }
}
