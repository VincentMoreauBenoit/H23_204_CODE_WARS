using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Empêche les classes de reçevoir un bloc dragable et delete celui-ci
public class DropDelete : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped.GetComponent<DragDrop>() != null) {
            dropped.GetComponent<DragDrop>().toDelete = true;
        }
        Ligne.verifLine();
    }
}
