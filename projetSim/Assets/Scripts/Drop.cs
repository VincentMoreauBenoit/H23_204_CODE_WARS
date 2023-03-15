using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    private RectTransform rectTransform;
    [SerializeField] private GameObject prefabLine;
    [SerializeField] private GameObject gameManager;

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

    }
}
