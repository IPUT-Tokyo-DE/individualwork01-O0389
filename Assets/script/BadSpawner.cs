using UnityEngine;

public class BadSpawner : MonoBehaviour
{
    public GameObject amePrefab;
    public float spawnInterval = 3f;
    public Vector2 spawnXRange = new Vector2(-13f, 14f);
    public float spawnY = 6.5f;

    public float intervalDecreaseRate = 0.1f; // ���ǉ�
    public float minSpawnInterval = 1f;        // ���ǉ�

    private float timeElapsed = 0f;             // ���ǉ�

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAme), 0f, spawnInterval);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        // ��10�b���Ƃ�spawnInterval��Z�k
        if (timeElapsed >= 10f)
        {
            timeElapsed = 0f;
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);

            // ����x�ݒ肵�����iInvokeRepeating���ƊԊu�����A���^�C���ύX�ł��Ȃ�����j
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