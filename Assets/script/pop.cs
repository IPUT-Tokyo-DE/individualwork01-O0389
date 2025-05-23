using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // 生成するPrefab（敵など）
    public float spawnInterval = 5f; // 初期の出現間隔
    public float spawnX = 14.9f;
    public float minY = -4.6f;
    public float maxY = 4.6f;

    public float intervalDecreaseRate = 0.1f; // ★減少量を0.1に変更！
    public float minSpawnInterval = 1f;       // 最小の出現間隔

    private float timer = 0f;
    private float timeElapsed = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        timeElapsed += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }

        // 10秒経過ごとに spawnInterval を短くする
        if (timeElapsed >= 10f)
        {
            timeElapsed = 0f;
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);
        }
    }

    void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Spawner: objectToSpawn が null または破壊されています！");
        }
    }
}