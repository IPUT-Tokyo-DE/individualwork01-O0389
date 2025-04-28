using UnityEngine;
using UnityEngine.SceneManagement; // シーン遷移を使用するために必要

public class StartScreenManager : MonoBehaviour
{
    public GameObject startText;  // 「Game Start」と「Please Enter」を表示するUIオブジェクト

    void Start()
    {
        // 最初にゲームを停止し、スタート画面のテキストを表示
        Time.timeScale = 0f;  // ゲームを停止
        startText.SetActive(true);  // テキストを表示
    }

    void Update()
    {
        // エンターキーが押されたらシーン遷移
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // ゲームを開始して、スタート画面を非表示にし、シーンを遷移
        Time.timeScale = 1f;  // ゲームを再開
        startText.SetActive(false);  // スタート画面のテキストを非表示にする

        // SampleSceneに遷移
        SceneManager.LoadScene("SampleScene");
    }
}