using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{

    private List<GameObject> EnemyMovePoints;

    EnemyRole enemyRole;

    bool isPlaying = false;
    int pointsInPathCounter;
    float wayLengthToTimeRatio=1f;

    public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
    public int PointsInPathCounter { get => pointsInPathCounter; set => pointsInPathCounter = value; }

    //Vector3[] PathVector1=new Vector3[2];
    //Vector3[] PathVector2=new Vector3[3];

    private void Awake()
    {

        EnemyMovePoints = MapManager.Instance.EnemyMovePoints;
        enemyRole = transform.GetComponent<EnemyRole>();

        //for (int i = 0; i < PathVector1.Length; i++) PathVector1[i] = EnemyMovePoints[i].transform.position;
        //for (int i = 0; i < PathVector2.Length; i++) PathVector2[i] = EnemyMovePoints[i+2].transform.position;

    }

    private void Start()
    {
        //transform.DOPath(PathVector1, 10f, PathType.Linear).SetEase(Ease.Linear).OnComplete(() =>
        //{
        //    print("ChangeDirection");
        //    transform.DOPath(PathVector2, 20f, PathType.Linear).SetEase(Ease.Linear);
        //});

    }

    
    private void Update()
    {

        if (!isPlaying)
        {
            isPlaying = true;
            float linsDistance = Vector3.Distance(transform.position, EnemyMovePoints[pointsInPathCounter].transform.position);

            if(pointsInPathCounter==2) print("Change Direction!");
            if (pointsInPathCounter == 3) print("Change Canvas Sorting!");

            transform.DOMove(EnemyMovePoints[pointsInPathCounter].transform.position, linsDistance*wayLengthToTimeRatio).SetEase(Ease.Linear).OnComplete(()=> {
                if (pointsInPathCounter >= EnemyMovePoints.Count) { 
                    isPlaying = true;             // 全部动画播放结束，不再循环
                    enemyRole.IsActiveGO = false;
                }
                else
                    isPlaying = false;
            });

            pointsInPathCounter++;
        }

    }


}



