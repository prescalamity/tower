using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateCannonController : UnityEngine.EventSystems.EventTrigger
{

    float timer;
    int createSpeed = 5;
    int CanCreateCannonTotal=15;

    private bool mouseIsHere = false;

    public bool MouseIsHere { get => mouseIsHere; set => mouseIsHere = value; }

    Text timerText;
    Text rateText;

    void Start()
    {
        //DebugTool.AddButton("CreateCannon", GameLoader.Instance.AddCannonToScene);
        timerText = transform.Find("TimerText").transform.GetComponent<Text>();
        rateText= transform.Find("RateText").transform.GetComponent<Text>();
        rateText.text = CanCreateCannonTotal + "/20";

        CannonManager.Instance.CannonEndDragAction += CreateEndDragCannonState;
    }


    void Update()
    {
        if(CanCreateCannonTotal < 20) {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = createSpeed;
                CanCreateCannonTotal++;
                rateText.text = CanCreateCannonTotal + "/20";

            }
            timerText.text = ((int)(timer + 0.98f)).ToString();
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (CanCreateCannonTotal > 0)
        {
            GameLoader.Instance.AddCannonToScene();
            CanCreateCannonTotal--;
            rateText.text = CanCreateCannonTotal + "/20";
        }
            
    }

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

    /// <summary>
    /// 处理鼠标结束拖拽大炮事件
    /// </summary>
    private void CreateEndDragCannonState(Cannon cannon)
    {
        if (MouseIsHere)
        {
            CannonManager.Instance.NotActiveCannon(cannon);
        }
           
    }

}
