using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FortBarbettesController : UnityEngine.EventSystems.EventTrigger
{

    private bool mouseIsHere=false;

    public bool MouseIsHere { get => mouseIsHere; set => mouseIsHere = value; }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        mouseIsHere = true;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        mouseIsHere = false;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
       
    }

    public override void OnDrag(PointerEventData eventData)
    {

    }


    public override void OnEndDrag(PointerEventData eventData)
    {
       
    }




}
