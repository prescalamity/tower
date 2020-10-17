using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CannonManager : Inst<CannonManager>
{

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
            if (!cannons[i].IsActiveGO) return i;
        }

        return -1;

    }

    /// <summary>
    /// 激活大炮
    /// </summary>
    /// <returns></returns>
    public void ActiveCannon(Vector3 position, int fortBarbettesId)
    {

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
    /// 激活跟随鼠标对象
    /// </summary>
    public void ActiveCFM(int Grade)
    {
        cannonFollowMouseView.SetGrade(Grade);
        cannonFollowMouseView.SetImage(SpriteAtlasManager.Instance.GetSprite("home_top_Fruits_number@2x"));

        Vector3 scenePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
           GameLoader.Instance.UiCamera.WorldToScreenPoint(cannonFollowMouseView.transform.position).z);
        cannonFollowMouseView.transform.position = GameLoader.Instance.UiCamera.ScreenToWorldPoint(scenePos);

        cannonFollowMouseView.gameObject.SetActive(true);
    }

    /// <summary>
    /// 取消跟随鼠标对象
    /// </summary>
    public void NotActionCFM()
    {
        cannonFollowMouseView.gameObject.SetActive(false);
    }




}





