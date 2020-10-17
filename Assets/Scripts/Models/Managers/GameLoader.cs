using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : Inst<GameLoader>
{

    /// <summary>
    /// 游戏加载时调用所有注册方法
    /// </summary>
    public Action GameLoadAction;

    /// <summary>
    /// 大炮资源预设
    /// </summary>
    private GameObject cannonPrefab;

    private GameObject enemyPrefab;

    private GameObject canvasGO;

    private Camera uiCamera;

    /// <summary>
    /// 已实例化的大炮属性列表
    /// </summary>
    private List<Cannon> Cannons;

    private List<EnemyRole> Enemies;

    public GameObject CannonPrefab { get => cannonPrefab; }
    public GameObject CanvasGO { get => canvasGO; }
    public GameObject EnemyPrefab { get => enemyPrefab; set => enemyPrefab = value; }
    public Camera UiCamera { get => uiCamera; }



    /// <summary>
    ///  加载资源
    /// </summary>
    private void Awake()
    {

        cannonPrefab = (GameObject)Resources.Load("Prefabs/Cannon");
        enemyPrefab = (GameObject)Resources.Load("Prefabs/Enemy");

        canvasGO = GameObject.Find("Canvas/MainView/MyMainView/Enemys");

        Cannons = CannonManager.Instance.Cannons;
        Enemies = EnemyManager.Instance.Enemies;


    }


    private void Start()
    {
        canvasGO = GameObject.Find("Canvas/MainView/MyMainView/Enemys");
        uiCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    /// <summary>
    /// 将资源加载到元素管理器中
    /// </summary>
    public void LoadGameElement()
    {
        
        //GameLoadAction?.Invoke();

    }

    /// <summary>
    /// 增加大炮到 游戏场景 和 管理器 中
    /// </summary>
    public void AddCannonToScene()
    {
        int linsId=CannonManager.Instance.GetFirstNotActiveCannon();
        if (linsId == -1)
        {
            CannonManager.Instance.AddCannon(Instantiate(cannonPrefab).GetComponent<Cannon>());
            Cannons[Cannons.Count - 1].transform.SetParent(canvasGO.transform, false);
            Cannons[Cannons.Count - 1].CannonID = Cannons.Count - 1;

            if (!MapManager.Instance.InstallCannonToFB(Cannons.Count - 1)) {
                Cannons[Cannons.Count - 1].gameObject.SetActive(false);
                print("炮台已满，大炮安装失败！");
            }


        }
        else
        {
            if(!MapManager.Instance.InstallCannonToFB(linsId)) print("炮台已满，大炮安装失败！");
        }

     }

    /// <summary>
    /// 增加敌人到 游戏场景 和 敌人管理器 中
    /// </summary>
    public void AddEnemyToScene()
    {
        int linsId = EnemyManager.Instance.GetFirstNotActiveEnemy();
        if (linsId == -1)
        {
            EnemyManager.Instance.AddEnemy(Instantiate(enemyPrefab).GetComponent<EnemyRole>());
            Enemies[Enemies.Count - 1].transform.SetParent(canvasGO.transform, false);
            Enemies[Enemies.Count - 1].CanvasSorting.enabled = true;
            Enemies[Enemies.Count - 1].transform.position = MapManager.Instance.MonsterBirthplace.transform.position;
        }
        else
        {
            EnemyManager.Instance.ActiveEnemy(linsId);
        }
     }





}






