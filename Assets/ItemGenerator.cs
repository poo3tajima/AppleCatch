using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.03f;

    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

    void Update()
    {
        // 出現時間を数える
        this.delta += Time.deltaTime;

        // 時間がたまったら、ランダムに生成
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);

            // 1～10の出た目が1,2だったら爆弾
            if (dice <= this.ratio)
            {
                item = Instantiate(bombPrefab);
            }
            else
            {
                item = Instantiate(applePrefab);
            }

            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}
