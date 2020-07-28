using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Being drag ");
        print("kaaj");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(" DRagging");
        print("kaaj");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped ");
        print("kaaj");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag ");
        print("kaaj");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked ");
        print("kaaj");
    }

}
