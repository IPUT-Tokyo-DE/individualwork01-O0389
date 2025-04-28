using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnCollision : MonoBehaviour
{
    public string resetTag = "ResetTrigger"; // 当たったらリセットする対象のタグ名

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(resetTag))
        {
            Debug.Log("リセットトリガーに接触：リセットします");
            ResetGame();
        }
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // シーンをリロード
    }
}