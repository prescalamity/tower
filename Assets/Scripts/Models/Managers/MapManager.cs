using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Inst<MapManager>
{

    private GameObject map;
    private GameObject mainCannon;
    private GameObject monsterBirthplace;
    private GameObject homePlace;
    private List<GameObject> fortBarbettes=new List<GameObject>();
    /// <summary>
    /// 第一维（行）保存该炮台是否被占领，以及第二维（行）所占领炮的等级
    /// </summary>
    private int[,] FortBarbettesStatusArray;

    private List<GameObject> enemyMovePoints = new List<GameObject>();

    public GameObject Map { get => map;  }
    public GameObject MainCannon { get => mainCannon; }
    public GameObject MonsterBirthplace { get => monsterBirthplace;  }
    public GameObject HomePlace { get => homePlace;  }
    public List<GameObject> FortBarbettes { get => fortBarbettes;  }
    public List<GameObject> EnemyMovePoints { get => enemyMovePoints;  }

    private void Awake()
    {

        map = GameObject.Find("Map");
        mainCannon = Map.transform.Find("MainCannon").gameObject;
        monsterBirthplace = Map.transform.Find("MonsterBirthplace").gameObject;
        homePlace = Map.transform.Find("HomePlace").gameObject;
        foreach (Transform item in Map.transform.Find("FortBarbettes")) fortBarbettes.Add(item.gameObject);
        FortBarbettesStatusArray = new int[2,fortBarbettes.Count];
        foreach (Transform item in Map.transform.Find("InflectionPoints")) enemyMovePoints.Add(item.gameObject);
        enemyMovePoints.Add(homePlace);
    }

    /// <summary>
    /// 没有有效位置返回-1
    /// </summary>
    /// <returns></returns>
    private int GetAvailableFortBarbettesID()
    {
        for (int i=0; i< FortBarbettesStatusArray.GetLength(1); i++)
        {
            
            if (FortBarbettesStatusArray[0, i] == 0) return i;
        }
        return -1;
    }

    /// <summary>
    /// 将炮安装在有效炮台，并激活大炮
    /// </summary>
    /// <param name="cannon"></param>
    /// <returns></returns>
    public bool InstallCannonToFB(int CannonID)
    {
       
        int Id = GetAvailableFortBarbettesID();
        if (Id != -1)
        {
            
            FortBarbettesStatusArray[0, Id] = 1;
            FortBarbettesStatusArray[1, Id] = CannonManager.Instance.Cannons[CannonID].Grade;

            // 激活大炮
            CannonManager.Instance.Cannons[CannonID].InitCannon();    //初始化大炮
            CannonManager.Instance.Cannons[CannonID].transform.position = FortBarbettes[Id].transform.position;  //设置大炮位置
            CannonManager.Instance.Cannons[CannonID].FortBarbettesId = Id;           //大炮安装位置ID

            return true;
        }

        return false;
    } 


}



