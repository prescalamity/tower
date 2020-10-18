using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 大炮的属性状态信息，和view脚本
/// </summary>
public class Cannon : RoleBase
{

    private int cannonID;
    private int fortBarbettesId=-1;
    private int grade=1;

    //private bool cannonSelected;

    private GameObject cannonImageGO;
    private Image cannonImage;
    private Text GradeText;
    private Transform selectedImage;

    private CannonsController cannonsController;
    private bool mouseIsHere;

    /// <summary>
    /// 占地图中炮坑的ID
    /// </summary>
    public int FortBarbettesId { get => fortBarbettesId; set => fortBarbettesId = value; }
    public int Grade { get => grade; set => grade = value; }
    //public bool CannonSelected { get => cannonSelected;
    //    set {
    //    cannonSelected = value;
    //        if (cannonSelected)
    //            SelectedImage.gameObject.SetActive(cannonSelected);
    //        else
    //            SelectedImage.gameObject.SetActive(!cannonSelected);
    //    }
    //}

    public CannonsController CannonsController { get => cannonsController; }
    public GameObject CannonImageGO { get => cannonImageGO;}
    public Transform SelectedImage { get => selectedImage; set => selectedImage = value; }
    public Image CannonImage { get => cannonImage; }
    public int CannonID { get => cannonID; set => cannonID = value; }
    public bool MouseIsHere { get => mouseIsHere; set => mouseIsHere = value; }

    private void Awake()
    {
        cannonImageGO = transform.Find("CannonImage").gameObject;
        cannonImage = CannonImageGO.GetComponent<Image>();

        GradeText = transform.Find("GradeBgImage").GetComponentInChildren<Text>();
        selectedImage = transform.Find("SelectedImage");
        cannonsController = transform.GetComponent<CannonsController>();
        attackDistance = 100;
    }

    /// <summary>
    /// 初始化大炮
    /// </summary>
    public void InitCannon()
    {
        //CannonImageSprite = cannonSprite;
        GradeText.text = grade.ToString();
    }

    /// <summary>
    /// 刷新大炮属性视图
    /// </summary>
    public void RefreshCannonView()
    {
        //CannonImageSprite = cannonSprite;
        GradeText.text = grade.ToString();
    }



}



