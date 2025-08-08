using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // 落下速度を定義
    public float dropSpeed = -0.03f;

    void Update()
    {
        // y軸で落下させる
        transform.Translate(0, this.dropSpeed, 0);

        // y座標が-1.0より下になったら、消す
        if (transform.position.y < -1.0f)
        {
            Destroy(gameObject);
        }
    }
}
