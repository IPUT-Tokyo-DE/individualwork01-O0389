using UnityEngine;
using UnityEngine.SceneManagement;  // シーン管理用

public class Ame : MonoBehaviour
{
    public float destroyY = -5f;

    private void Update()
    {
        if (transform.position.y <= destroyY)
        {
            Destroy(gameObject);
        }

        // ゲームが停止している場合にRキーを押すとシーンを「start」にリロード
        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("start");  // シーン「start」に遷移
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BouncePad"))
        {
            // BouncePadタグの物体に当たったら衝突を無視する
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            return;
        }

        if (collision.collider.CompareTag("Target"))
        {
            // Targetに当たったらゲーム停止
            Time.timeScale = 0f;
            Debug.Log("Game Over!");
        }
    }
}