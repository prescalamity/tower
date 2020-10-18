using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Inst<MapManager>
{

    private GameObject map;
    private GameObject mainCannon;
    private GameObject monsterBirthplace;
    private GameObject homePlace;
    private List<FortBarbettesController> fortBarbettes=new List<FortBarbettesController>();
    /// <summary>
    /// 第一维（行）保存该炮台是否被占领，以及第二维（行）所占领炮的等级
    /// </summary>
    private int[,] fortBarbettesStatusArray;

    private List<GameObject> enemyMovePoints = new List<GameObject>();

    public GameObject Map { get => map;  }
    public GameObject MainCannon { get => mainCannon; }
    public GameObject MonsterBirthplace { get => monsterBirthplace;  }
    public GameObject HomePlace { get => homePlace;  }
    public List<FortBarbettesController> FortBarbettes { get => fortBarbettes;  }
    public List<GameObject> EnemyMovePoints { get => enemyMovePoints;  }
    public int[,] FortBarbettesStatusArray { get => fortBarbettesStatusArray;  }

    private void Awake()
    {

        map = GameObject.Find("Map");
        mainCannon = Map.transform.Find("MainCannon").gameObject;
        monsterBirthplace = Map.transform.Find("MonsterBirthplace").gameObject;
        homePlace = Map.transform.Find("HomePlace").gameObject;
        foreach (Transform item in Map.transform.Find("FortBarbettes")) fortBarbettes.Add(item.gameObject.GetComponent<FortBarbettesController>());
        fortBarbettesStatusArray = new int[2,fortBarbettes.Count];
        foreach (Transform item in Map.transform.Find("InflectionPoints")) enemyMovePoints.Add(item.gameObject);
        enemyMovePoints.Add(homePlace);

        CannonManager.Instance.CannonEndDragAction += MapEndDragCannonState;
    }

    /// <summary>
    /// 没有有效位置返回-1
    /// </summary>
    /// <returns></returns>
    private int GetAvailableFortBarbettesID()
    {
        for (int i=0; i< fortBarbettesStatusArray.GetLength(1); i++)
        {
            
            if (fortBarbettesStatusArray[0, i] == 0) return i;
        }
        return -1;
    }

    /// <summary>
    /// 将炮安装在有效炮台，并激活大炮
    /// </summary>
    /// <param name="cannon"></param>
    /// <returns></returns>
    public bool InstallCannonToFB(int CannonID, int InitGrade)
    {
        
         int  FortBarbettesID = GetAvailableFortBarbettesID();

        if (FortBarbettesID != -1)
        {
            
            fortBarbettesStatusArray[0, FortBarbettesID] = 1;
            fortBarbettesStatusArray[1, FortBarbettesID] = CannonManager.Instance.Cannons[CannonID].Grade;

            // 激活大炮
            CannonManager.Instance.Cannons[CannonID].Grade = InitGrade;
            CannonManager.Instance.Cannons[CannonID].InitCannon();    //初始化大炮
            CannonManager.Instance.Cannons[CannonID].transform.position = FortBarbettes[FortBarbettesID].transform.position;  //设置大炮位置
            CannonManager.Instance.Cannons[CannonID].FortBarbettesId = FortBarbettesID;           //大炮安装位置ID
            CannonManager.Instance.Cannons[CannonID].gameObject.SetActive(true);

            return true;
        }

        return false;
    }

    public void ExchangeTwoCannons(Cannon cannon1, Cannon cannon2)
    {
        int cannon1FortBarbettesID = cannon1.FortBarbettesId;

        fortBarbettesStatusArray[1, cannon2.FortBarbettesId] = cannon1.Grade;
        cannon1.transform.position = FortBarbettes[cannon2.FortBarbettesId].transform.position;  //设置大炮位置
        cannon1.FortBarbettesId = cannon2.FortBarbettesId;           //大炮安装位置ID

        fortBarbettesStatusArray[1, cannon1FortBarbettesID] = cannon2.Grade;
        cannon2.transform.position = FortBarbettes[cannon1FortBarbettesID].transform.position;  //设置大炮位置
        cannon2.FortBarbettesId = cannon1FortBarbettesID;           //大炮安装位置ID
    }

    /// <summary>
    /// 处理鼠标结束拖拽大炮事件
    /// </summary>
    private void MapEndDragCannonState( Cannon cannon)
    {

        // 取消被选大炮等级， 并判断是否可以合并
        for (int i = 0; i < fortBarbettes.Count; i++)
        {
            if (fortBarbettes[i].MouseIsHere  && i != cannon.FortBarbettesId) 
            {
                // 从地图中拆除大炮
                fortBarbettesStatusArray[0, cannon.FortBarbettesId] = 0;

                //从新安装大炮
                fortBarbettesStatusArray[0, i] = 1;
                fortBarbettesStatusArray[1, i] = cannon.Grade;

                cannon.gameObject.transform.position = FortBarbettes[i].transform.position;
                cannon.FortBarbettesId = i;
               
            }
        }


    }

}



