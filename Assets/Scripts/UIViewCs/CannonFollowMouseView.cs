using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonFollowMouseView : MonoBehaviour
{

    public Camera UICamera;
    Vector3 scenePos;

    private Text GradeText;
    private Image CannonImage;

    private void Awake()
    {
        InitCFMV();
    }

    void Start()
    {
      
    }

    public void InitCFMV()
    {
        GradeText = transform.Find("GradeBgImage").GetComponentInChildren<Text>();
        CannonImage = transform.Find("CannonImage").GetComponent<Image>();
        UICamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        print(transform.position + "   AAAAAAAA  " + Input.mousePosition);
    }

    public void SetGrade(int Grade)
    {
        GradeText.text = Grade.ToString();
    }

    public void SetImage(Sprite sprite)
    {
        CannonImage.sprite = sprite;
    }

    void Update()
    {
        //transform.position = Input.mousePosition;

        Vector2 mous = Input.mousePosition;
        scenePos = new Vector3(mous.x, mous.y, UICamera.WorldToScreenPoint(transform.position).z);   // 
        transform.position = UICamera.ScreenToWorldPoint(scenePos);
    }
}
