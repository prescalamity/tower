using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 大炮的属性状态信息
/// </summary>
public class Cannon : RoleBase
{

    private int fortBarbettesId=-1;
    private int grade=1;

    private bool cannonSelected;

    private Sprite CannonImageSprite;
    private Text GradeText;
    private Transform SelectedImage;

    private CannonsController cannonsController;

    public int FortBarbettesId { get => fortBarbettesId; set => fortBarbettesId = value; }
    public int Grade { get => grade; set => grade = value; }
    public bool CannonSelected { get => cannonSelected;
        set {
            cannonSelected = value;
            if (cannonSelected)
                SelectedImage.gameObject.SetActive(cannonSelected);
            else
                SelectedImage.gameObject.SetActive(!cannonSelected);
        }
    }

    public CannonsController CannonsController { get => cannonsController; }

    private void Awake()
    {
        CannonImageSprite = transform.Find("CannonImage").GetComponent<Image>().sprite;
        GradeText = transform.Find("GradeBgImage").GetComponentInChildren<Text>();
        SelectedImage = transform.Find("SelectedImage");
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
    /// 刷新大炮属性
    /// </summary>
    public void RefreshCannon()
    {
        //CannonImageSprite = cannonSprite;
        //GradeText.text = grade.ToString();
    }



}



