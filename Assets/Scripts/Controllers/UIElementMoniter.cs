using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIElementMoniter : UnityEngine.EventSystems.EventTrigger
{

    public UnityAction ElementClickedAction;

    public override void OnPointerClick(PointerEventData eventData)
    {
        //print("AAAAAAAAAAAAAAA");
        ElementClickedAction?.Invoke();
    }




}






