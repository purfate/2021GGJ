using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// 玩家分數
    /// </summary>
    private int Score;

    /// <summary>
    /// 分數每秒(?)增加參數
    /// </summary>
    private int ScoreAdd;

    /// <summary>
    /// 顯示文字(可能替換)
    /// </summary>
    public Text ScoreText;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Beacon")
        {

        }
    }

    private void Start()
    {
        //將功能加入訂閱(進入、離開訊號發送點)
        GameManager.gameManager.OnTriggerBeaconIn += BeaconIn;
        GameManager.gameManager.OnTriggerBeaconExit += BeaconExit;
        this.Score = 0;
        this.ScoreAdd = -1;
        //開始跑分數計算器
        StartCoroutine(ScoreAddIEnum());
    }

    private void Update()
    {
        


    }

    /// <summary>
    /// 玩家進入訊號範圍
    /// </summary>
    /// <param name="Tag"></param>
    /// <param name="Num"></param>
    private void BeaconIn(string Tag, int Num)
    {
        if (Tag.Equals(this.tag))
        {
           
            this.ScoreAdd = Num;
        }
    }

    /// <summary>
    /// 玩家離開訊號範圍
    /// </summary>
    /// <param name="Tag"></param>
    private void BeaconExit(string Tag)
    {
        if (Tag.Equals(this.tag))
        {
            this.ScoreAdd = -1;
        }
    }

    /// <summary>
    /// 分數計算器，依設定頻率增加或減少玩家的分數
    /// </summary>
    /// <returns></returns>
    IEnumerator ScoreAddIEnum()
    {
        yield return new WaitForSeconds(1);
        this.Score += this.ScoreAdd;
        if (this.Score <= 0)
        {
            this.Score = 0;
        }
        if (this.Score >= 100)
        {
            this.Score = 100;
        }
        this.ScoreText.text = this.Score.ToString();

        StartCoroutine(ScoreAddIEnum());
    }

}
