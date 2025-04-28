using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理用

public class DangerObject : MonoBehaviour
{
    public float lifetime = 2f;  // オブジェクトの寿命（消えるまでの時間）

    [Header("サイズ設定")]
    public Vector2 objectSize = new Vector2(1f, 1f);  // サイズ設定

    void Start()
    {
        // サイズ設定
        transform.localScale = new Vector3(objectSize.x, objectSize.y, 1f);
        // 一定時間後に削除
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Targetタグを持つオブジェクトに触れたらゲームを停止
        if (other.CompareTag("Target"))
        {
            Debug.Log("Targetが危険オブジェクトに触れた！ゲーム停止！");
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        // ゲームが停止している場合にRキーを押すとシーンを「start」にリロード
        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("start");  // シーン「start」に遷移
        }
    }
}