using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : Inst<EnemyManager>
{

    public UnityAction<GameObject> TheEnemyHpIsZeroAction;

    private List<EnemyRole> enemies = new List<EnemyRole>();


    public List<EnemyRole> Enemies { get => enemies;  }




    /// <summary>
    /// 增加敌人 到 敌人管理器 中
    /// </summary>
    /// <param name="enemyRole"></param>
    /// <returns></returns>
    public bool AddEnemy(EnemyRole enemyRole)
    {
        if (enemyRole != null)
        {
            enemies.Add(enemyRole);
            
            return true;
        }
        return false;
    }

    /// <summary>
    /// 获得第一个不活动的敌人的ID，如果找不到返回-1
    /// </summary>
    /// <returns></returns>
    public int GetFirstNotActiveEnemy()
    {

        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].gameObject.activeInHierarchy) return i;
        }

        return -1;

    }

    public void ActiveEnemy(int EnemyID)
    {
        Enemies[EnemyID].transform.position = MapManager.Instance.MonsterBirthplace.transform.position;
        Enemies[EnemyID].gameObject.SetActive(true);
        Enemies[EnemyID].EnemiesController.IsPlaying = false;
        Enemies[EnemyID].EnemiesController.PointsInPathCounter = 0;
    }

}









