using UnityEngine;

public class BadSpawner : MonoBehaviour
{
    public GameObject amePrefab;
    public float spawnInterval = 3f;
    public Vector2 spawnXRange = new Vector2(-13f, 14f);
    public float spawnY = 6.5f;

    public float intervalDecreaseRate = 0.1f; // ★追加
    public float minSpawnInterval = 1f;        // ★追加

    private float timeElapsed = 0f;             // ★追加

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAme), 0f, spawnInterval);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        // ★10秒ごとにspawnIntervalを短縮
        if (timeElapsed >= 10f)
        {
            timeElapsed = 0f;
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);

            // ★一度設定し直す（InvokeRepeatingだと間隔をリアルタイム変更できないから）
            CancelInvoke(nameof(SpawnAme));
            InvokeRepeating(nameof(SpawnAme), spawnInterval, spawnInterval);
        }
    }

    void SpawnAme()
    {
        float randomX = Random.Range(spawnXRange.x, spawnXRange.y);
        Vector2 spawnPos = new Vector2(randomX, spawnY);
        Instantiate(amePrefab, spawnPos, Quaternion.identity);
    }
}