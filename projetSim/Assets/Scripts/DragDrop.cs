using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool provientBanque = true;
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject prefabBloc;
    [HideInInspector] public RectTransform parentAfterDrag;
    [HideInInspector] public bool toDelete = false;



    private void Start(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        parentAfterDrag = GetComponentInParent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts= false;
        canvasGroup.alpha = .6f;
        rectTransform.SetParent(rectTransform.root);
        rectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts= true;
        rectTransform.SetParent(parentAfterDrag);
        if (provientBanque)
        {
            GameObject bloc;
            if (toDelete)
            {
                toDelete = false;
                bloc = Instantiate(prefabBloc);
                toDelete = true;
            }
            else
            {
                bloc = Instantiate(prefabBloc);
            }
             bloc.GetComponent<RectTransform>().SetParent(content.GetComponent<RectTransform>());
             var rect = bloc.GetComponent<RectTransform>();
             rect.localPosition = GetComponent<RectTransform>().localPosition;
             var compBloc = bloc.GetComponent<Bloc>();
             rect.SetSiblingIndex(compBloc.GetSiblingIndex());
             Vector3 temp = rect.localScale;
             temp.x /= temp.x;
             temp.y /= temp.y;
             temp.z /= temp.z;
             rect.localScale = temp;
            
        }

        
        provientBanque = false;

        if(toDelete)
        {
           
            Destroy(GetComponent<RectTransform>().gameObject);
        }
    }
}
