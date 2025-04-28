using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // UIのテキストを使うため

public class GameOverManager : MonoBehaviour
{
    public Text gameOverText;  // 経過時間を表示するテキスト
    private float timeElapsed = 0f;  // 経過秒数
    private bool isGameOver = false; // ゲームオーバーかどうか

    void Update()
    {
        // ゲームオーバー状態であれば経過時間を表示
        if (isGameOver)
        {
            timeElapsed += Time.deltaTime;

            // 経過時間をテキストに表示
            gameOverText.text = "Game Over\nTime Elapsed: " + timeElapsed.ToString("F2") + " seconds";

            // Rキーが押されたら、現在のシーンをリセット
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 現在のシーンを再ロード
            }
        }
        else
        {
            // ゲームオーバーでない状態ではテキストを非表示
            gameOverText.text = ""; // ゲームオーバー以外ではテキストをクリア
        }
    }

    // ゲームオーバーを発生させるメソッド
    public void TriggerGameOver()
    {
        // ゲームオーバーを発生させる
        Time.timeScale = 0f;  // ゲーム停止
        isGameOver = true;  // ゲームオーバー状態にする
    }

    // 例：衝突時にゲームオーバーを発生させる
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // 例：敵に衝突したとき
        {
            TriggerGameOver();  // ゲームオーバーを呼び出す
        }
    }
}