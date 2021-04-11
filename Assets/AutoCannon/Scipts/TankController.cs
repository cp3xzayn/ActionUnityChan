using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    /// <summary>動く速さ</summary>
    [SerializeField] float m_movingSpeed = 5f;
    /// <summary>ターンの速さ</summary>
    [SerializeField] float m_turnSpeed = 3f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        
        // 左右で回転させる
        if (h != 0)
        {
            this.transform.Rotate(this.transform.up, h * m_turnSpeed);
        }

        // 上下で前後移動する。ジャンプした時の y 軸方向の速度は保持する。
        Vector3 velo = this.transform.forward * m_movingSpeed * v;
        velo.y = rb.velocity.y;
        rb.velocity = velo;
    }
}
