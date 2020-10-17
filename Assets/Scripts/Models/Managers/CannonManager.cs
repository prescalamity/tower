using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CannonManager : Inst<CannonManager>
{

    public Action<Cannon> CannonEndDragAction;

    /// <summary>
    /// 已实例化大炮
    /// </summary>
    private List<Cannon> cannons = new List<Cannon>();

    private Cannon mainCannon;

    private CannonFollowMouseView cannonFollowMouseView;

    /// <summary>
    /// 已实例化的大炮属性列表
    /// </summary>
    public List<Cannon> Cannons { get => cannons; }
    public CannonFollowMouseView CannonFollowMouseView { get => cannonFollowMouseView; set => cannonFollowMouseView = value; }

    private void Awake()
    {
        GameControl.Instance.hasGotMaxGradeChange += UpdateMainCannon;
        CannonEndDragAction += CannonEndDragCannonState;
    }

    private void Start()
    {
        cannonFollowMouseView = Instantiate((GameObject)Resources.Load("Prefabs/CannonFollowMouse")).GetComponent<CannonFollowMouseView>();
        cannonFollowMouseView.gameObject.SetActive(false);
        cannonFollowMouseView.gameObject.transform.SetParent(GameObject.Find("Canvas/MainView").transform, false);
    }

    /// <summary>
    /// 增加炮到管理器中
    /// </summary>
    /// <param name="cannon"></param>
    /// <returns></returns>
    public bool AddCannon(Cannon cannon)
    {
        if (cannon != null)
        {
            cannons.Add(cannon);
            GameControl.Instance.HasGotMaxGrade = cannon.Grade;
            return true;
        }
        return false;
    }

    /// <summary>
    /// 获得第一个不活动的炮的ID，如果找不到返回-1
    /// </summary>
    /// <returns></returns>
    public int GetFirstNotActiveCannon()
    {

        for (int i = 0; i < cannons.Count; i++)
        {
            if (!cannons[i].gameObject.activeInHierarchy) return i;
        }

        return -1;

    }

    /// <summary>
    /// 取消大炮激活状态
    /// </summary>
    /// <returns></returns>
    public void NotActiveCannon(Cannon  cannon)
    {
        cannon.gameObject.SetActive(false);

        // 从地图中拆除大炮
        MapManager.Instance.FortBarbettesStatusArray[0, cannon.FortBarbettesId] = 0;
    }

    /// <summary>
    /// 更新主炮信息
    /// </summary>
    public void UpdateMainCannon()
    {
        if (mainCannon == null)
        {
            mainCannon = Instantiate(GameLoader.Instance.CannonPrefab).GetComponent<Cannon>();
            mainCannon.transform.SetParent(GameLoader.Instance.CanvasGO.transform, false);
            mainCannon.transform.position = MapManager.Instance.MainCannon.transform.position;
        }
        else
        {
            mainCannon.Grade = GameControl.Instance.HasGotMaxGrade;

        }
    }

    /// <summary>
    ///  处理鼠标开始拖拽大炮事件
    /// </summary>
    /// <param name="SelectedGrade"></param>
    /// <param name="CannonID"></param>
    public void BeginDragCannonState(int SelectedGrade, int CannonID)
    {
        // 激活跟随鼠标对象
        cannonFollowMouseView.SetGrade(SelectedGrade);
        cannonFollowMouseView.SetImage(SpriteAtlasManager.Instance.GetSprite("home_top_Fruits_number@2x"));

        Vector3 scenePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
           GameLoader.Instance.UiCamera.WorldToScreenPoint(cannonFollowMouseView.transform.position).z);
        cannonFollowMouseView.transform.position = GameLoader.Instance.UiCamera.ScreenToWorldPoint(scenePos);

        cannonFollowMouseView.gameObject.SetActive(true);

        // 激活被选大炮等级
        for (int i = 0; i < cannons.Count; i++)
        {
            if (cannons[i].Grade == SelectedGrade && i != CannonID) cannons[i].SelectedImage.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 处理鼠标结束拖拽大炮事件
    /// </summary>
    private void CannonEndDragCannonState(Cannon SelectedCannon)
    {
        // 取消跟随鼠标对象
        cannonFollowMouseView.gameObject.SetActive(false);


        // 取消被选大炮等级， 并判断是否可以合并
        for (int i = 0; i < cannons.Count; i++)
        {
            cannons[i].SelectedImage.gameObject.SetActive(false);

            if(cannons[i].MouseIsHere && cannons[i].Grade== SelectedCannon.Grade && cannons[i].CannonID!= SelectedCannon.CannonID)
            {
                print("可以合并");
            }
        }

        
    }



}





