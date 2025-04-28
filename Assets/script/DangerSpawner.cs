using UnityEngine;

public class DangerSpawner : MonoBehaviour
{
    public GameObject dangerPrefab;   // 生成するオブジェクトのプレハブ
    public float spawnInterval = 5f;  // 生成間隔

    [Header("出現範囲")]
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    public float intervalDecreaseRate = 0.1f; // ★追加：減少量
    public float minSpawnInterval = 1f;        // ★追加：最小間隔

    private float timer = 0f;
    private float timeElapsed = 0f;             // ★追加：経過時間カウント用

    void Update()
    {
        timer += Time.deltaTime;
        timeElapsed += Time.deltaTime; // ★追加

        if (timer >= spawnInterval)
        {
            SpawnDanger();
            timer = 0f;
        }

        // ★10秒ごとにspawnIntervalを減らす
        if (timeElapsed >= 10f)
        {
            timeElapsed = 0f;
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);
        }
    }

    void SpawnDanger()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPos = new Vector2(randomX, randomY);

        GameObject newDanger = Instantiate(dangerPrefab, spawnPos, Quaternion.identity);

        // サイズをランダムに変更 (X: 1~3, Y: 1~3)
        float randomScaleX = Random.Range(1f, 3f);
        float randomScaleY = Random.Range(1f, 3f);
        newDanger.transform.localScale = new Vector3(randomScaleX, randomScaleY, 1f);
    }
}