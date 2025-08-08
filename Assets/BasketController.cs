using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple();
        }
        else
        {
            this.aud.PlayOneShot(this.bombSE);
            this.director.GetComponent<GameDirector>().GetBomb();
        }
        Destroy(other.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // RaycastHitという構造体を宣言
            RaycastHit hit;

            // out hit で参照渡ししている
            // rayがタップされた場所のコライダーにぶつかるとき、
            // hitが初期化される
            // Mathf.Infinity 無限光線をつかう
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // hitしたxz座標を四捨五入して代入
                // 値-1.0, 0, 1.0となる
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
