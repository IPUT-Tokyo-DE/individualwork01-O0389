using UnityEngine;

public class PauseOnTrigger : MonoBehaviour
{
    public string pauseTag = "PauseTrigger";  // 当たるとゲームを停止するオブジェクトのタグ

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(pauseTag))
        {
            Debug.Log("ゲーム停止トリガーに接触：ゲームを一時停止します");
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // ゲーム時間を停止
    }
}