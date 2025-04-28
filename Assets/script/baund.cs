using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    public float bounceForce = 10f; // 跳ねる強さ

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BouncePad"))
        {
            // 任意の方向（上下左右含む）にランダムな単位ベクトルを生成
            Vector2 randomDirection = new Vector2(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ).normalized;

            // 跳ね返り速度を設定
            rb.linearVelocity = randomDirection * bounceForce;
        }
    }
}