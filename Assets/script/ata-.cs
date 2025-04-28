using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // UIのTextを使うために必要

public class PauseOnBulletContact : MonoBehaviour
{
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    public static bool isGameOver = false;
    private float elapsedTime = 0f;

    public Text gameOverText;  // 経過時間を表示するTextコンポーネント

    void Start()
    {
        // ゲーム開始時にTextを非表示にしておく
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver)
        {
            // ゲームオーバー後、経過時間を表示し、スペースキーを押すとシーン遷移
            if (gameOverText != null)
            {
                gameOverText.text = $"Game Over\nTime Elapsed: {elapsedTime:F2} seconds";
                gameOverText.gameObject.SetActive(true);  // 経過時間のテキストを表示
            }

            // スペースキーでシーン「start」に戻る
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("start");
            }

            return;
        }

        elapsedTime += Time.deltaTime;  // 経過時間を加算

        Vector2 pos = transform.position;

        // 指定範囲外に出た場合の処理
        if (pos.x < minX || pos.x > maxX || pos.y < minY || pos.y > maxY)
        {
            Debug.Log($"指定範囲外に出たため、経過時間: {elapsedTime:F2}秒");
            GameOver();  // ゲームオーバー処理
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log($"Bulletに接触：経過時間: {elapsedTime:F2}秒");
            GameOver();  // ゲームオーバー処理
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;  // ゲームを停止
        isGameOver = true;    // ゲームオーバー状態にする
    }
}