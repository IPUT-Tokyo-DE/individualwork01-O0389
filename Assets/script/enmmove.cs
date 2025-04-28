using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BuggyMover : MonoBehaviour
{
    public float forwardSpeed = 2f;
    public float jitterForce = 2f;
    public float jitterInterval = 0.2f;
    public float destroyX = -14f;

    private Rigidbody2D rb;
    private float jitterTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // 重力無効
    }

    void Update()
    {
        // 常に左方向に進む（縦方向の速度を保持）
        Vector2 currentVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector2(-forwardSpeed, currentVelocity.y);

        // 一定間隔でランダムな力を加える
        jitterTimer += Time.deltaTime;
        if (jitterTimer >= jitterInterval)
        {
            Vector2 randomJitter = Random.insideUnitCircle.normalized * jitterForce;
            rb.AddForce(randomJitter, ForceMode2D.Impulse);
            jitterTimer = 0f;
        }

        // タグが "Bullet" のときのみ削除
        if (CompareTag("Bullet") && transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }
}