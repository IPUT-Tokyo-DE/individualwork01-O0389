using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    // ゲーム開始前に表示するUI（例: "Press Enter to Start" などのメッセージ）
    public GameObject startUI;

    void Start()
    {
        // ゲーム開始時に一時停止し、UIを表示
        Time.timeScale = 0f;  // ゲームを停止
        startUI.SetActive(true);  // UIを表示
    }

    void Update()
    {
        // エンターキーが押されたらゲームを開始
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // ゲームを開始
        Time.timeScale = 1f;  // ゲームを再開
        startUI.SetActive(false);  // UIを非表示にする
    }
}