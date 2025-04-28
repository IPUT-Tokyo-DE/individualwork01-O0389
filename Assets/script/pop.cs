using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // ê∂ê¨Ç∑ÇÈPrefabÅiìGÇ»Ç«Åj
    public float spawnInterval = 5f; // èâä˙ÇÃèoåªä‘äu
    public float spawnX = 14.9f;
    public float minY = -4.6f;
    public float maxY = 4.6f;

    public float intervalDecreaseRate = 0.1f; // Åöå∏è≠ó Ç0.1Ç…ïœçXÅI
    public float minSpawnInterval = 1f;       // ç≈è¨ÇÃèoåªä‘äu

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

        // 10ïbåoâﬂÇ≤Ç∆Ç… spawnInterval ÇíZÇ≠Ç∑ÇÈ
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
            Debug.LogWarning("Spawner: objectToSpawn Ç™ null Ç‹ÇΩÇÕîjâÛÇ≥ÇÍÇƒÇ¢Ç‹Ç∑ÅI");
        }
    }
}