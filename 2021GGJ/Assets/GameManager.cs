using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 設定全域變數(用於其他物件使用)
    /// </summary>
    public static GameManager gameManager;

    private void Awake()
    {
        //宣告(重要)
        gameManager = this;
    }

    /// <summary>
    /// 訂閱事件:玩家進入訊號範圍
    /// </summary>
    public event Action<string,int> OnTriggerBeaconIn;
    /// <summary>
    /// 訂閱事件觸發:玩家進入訊號範圍
    /// </summary>
    /// <param name="PlayerTag">玩家標籤</param>
    /// <param name="AddScore">欲增加分數</param>
    public void TriggerBeaconIn(string PlayerTag,int AddScore)
    {
        if (OnTriggerBeaconIn != null)
        {
            OnTriggerBeaconIn(PlayerTag, AddScore);
        }
    }

    /// <summary>
    /// 訂閱事件:玩家離開訊號範圍
    /// </summary>
    public event Action<string> OnTriggerBeaconExit;
    /// <summary>
    /// 訂閱事件觸發:玩家離開訊號範圍
    /// </summary>
    /// <param name="PlayerTag">玩家標籤</param>
    public void TriggerBeaconExit(string PlayerTag)
    {
        if (OnTriggerBeaconExit != null)
        {
            OnTriggerBeaconExit(PlayerTag);
        }
    }
}
