using UnityEngine;

public class StartGameOnEnter : MonoBehaviour
{
    public GameObject titleScreenUI; // タイトル画面のUI（Canvasなど）

    private bool hasStarted = false; // 一度だけスタートするためのフラグ

    void Start()
    {
        // ゲームを停止状態に
        Time.timeScale = 0f;

       
    }

    void Update()
    {
        if (!hasStarted && Input.GetKeyDown(KeyCode.Return)) ; // Enterキーで開始
        
    }
}