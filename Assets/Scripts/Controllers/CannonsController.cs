using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CannonsController : UnityEngine.EventSystems.EventTrigger
{

    Cannon cannon;

    private void Awake()
    {
        cannon = transform.GetComponent<Cannon>();
    }

    //public override void OnPointerClick(PointerEventData eventData)
    //{
    //    print("AAAAAAAAAAAAAA");
    //}

    //public override void OnPointerDown(PointerEventData eventData)
    //{
    //    print("BBBBBBBBBBBBBBB");
    //}

    public override void OnPointerEnter(PointerEventData eventData)
    {
        //print("CCCCCCCCCCCCCCCCCC");
        cannon.MouseIsHere = true;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        cannon.MouseIsHere = false;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        //print("DDDDDDDDDDDDDDDDDDDDD");
        cannon.CannonImage.color = new Color(1f, 1f, 1f, 0.5f);
        CannonManager.Instance.BeginDragCannonState(cannon.Grade, cannon.CannonID);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        
    }


    public override void OnEndDrag(PointerEventData eventData)
    {
        cannon.CannonImage.color = new Color(1f, 1f, 1f, 1f);
        CannonManager.Instance.CannonEndDragAction?.Invoke(cannon);
    }

}
