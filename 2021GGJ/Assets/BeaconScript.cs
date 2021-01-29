using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconScript : MonoBehaviour
{
    /// <summary>
    /// 此訊號增加分數量
    /// </summary>
    public int ScoreAdd;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //檢查碰撞物件層級是否為編號6(玩家Layer)
        if (collision.gameObject.layer == 6)
        {
            Debug.Log(collision.tag+" In!!");
            //觸發訂閱事件
            GameManager.gameManager.TriggerBeaconIn(collision.tag, ScoreAdd);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //檢查碰撞物件層級是否為編號6(玩家Layer)
        if (collision.gameObject.layer == 6)
        {
            Debug.Log(collision.tag + " Exit!!");
            //觸發訂閱事件
            GameManager.gameManager.TriggerBeaconExit(collision.tag);
        }
    }
}
