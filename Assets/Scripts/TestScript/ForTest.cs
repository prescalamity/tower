using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ForTest : UnityEngine.EventSystems.EventTrigger
{

    float timer;
    int createSpeed = 5;
    int CanCreateCannonTotal=15;

    Text timerText;
    Text rateText;

    void Start()
    {
        //DebugTool.AddButton("CreateCannon", GameLoader.Instance.AddCannonToScene);
        timerText = transform.Find("TimerText").transform.GetComponent<Text>();
        rateText= transform.Find("RateText").transform.GetComponent<Text>();
        rateText.text = CanCreateCannonTotal + "/20";
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

    public void Testttttt()
    {

    }
}
