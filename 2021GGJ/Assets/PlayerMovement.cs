using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家控制
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// 使用的Input名稱(水平方向)
    /// </summary>
    public string InputHorizontal;

    /// <summary>
    /// 使用的Input名稱(垂直方向)
    /// </summary>
    public string InputVertical;

    /// <summary>
    /// 移動參數
    /// </summary>
    private Vector2 movement;

    /// <summary>
    /// 移動速度
    /// </summary>
    public float MoveSpeed;

    /// <summary>
    /// 碰撞器
    /// </summary>
    private Rigidbody2D rb;

    private void Awake()
    {
        //取得此物件的碰撞器
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        //移動參數比照使用者輸入的內容
        movement.x = Input.GetAxis(InputHorizontal);
        movement.y = Input.GetAxis(InputVertical);
    }

    private void FixedUpdate()
    {
        //依照移動參數*速度決定移動
        this.rb.MovePosition(this.rb.position+this.movement*MoveSpeed*Time.deltaTime);
    }
}
