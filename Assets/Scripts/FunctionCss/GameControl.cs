
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 游戏控制器
/// </summary>
public class GameControl : Inst<GameControl>
{
    /// <summary>
    /// 当有
    /// </summary>
    public UnityAction hasGotMaxGradeChange;

    private int hasGotMaxGrade;

    public int HasGotMaxGrade { get => hasGotMaxGrade; set {
            if (value> hasGotMaxGrade)
            {
                hasGotMaxGrade = value;
                hasGotMaxGradeChange?.Invoke();
            }
        }
    }
}
