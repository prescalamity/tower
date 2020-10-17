using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRole : RoleBase
{

    /// <summary>
    /// 角色血量
    /// </summary>
    private int hP;
    private string enemyName;

    /// <summary>
    /// 用于设置UI的遮盖层级
    /// </summary>
    private Canvas canvasSorting;

    private EnemiesController enemiesController;

    public int HP { get => hP;
        set {
            hP = value;
            EnemyManager.Instance.TheEnemyHpIsZeroAction?.Invoke(gameObject);
        }
    }

    public string EnemyName { get => enemyName; set => enemyName = value; }
    public Canvas CanvasSorting { get => canvasSorting;  }
    public EnemiesController EnemiesController { get => enemiesController; }

    private void Awake()
    {
        attackDistance = 10;
        attack = 20;
        canvasSorting = transform.GetComponent<Canvas>();
        enemiesController = transform.GetComponent<EnemiesController>();
    }

}







