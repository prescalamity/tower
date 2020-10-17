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
        print("CCCCCCCCCCCCCCCCCC");
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        //print("DDDDDDDDDDDDDDDDDDDDD");
        CannonManager.Instance.ActiveCFM(cannon.Grade);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        
    }


    public override void OnEndDrag(PointerEventData eventData)
    {
        print("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
        CannonManager.Instance.NotActionCFM();
    }

}
