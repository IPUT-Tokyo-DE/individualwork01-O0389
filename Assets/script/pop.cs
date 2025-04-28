using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // ��������Prefab�i�G�Ȃǁj
    public float spawnInterval = 5f; // �����̏o���Ԋu
    public float spawnX = 14.9f;
    public float minY = -4.6f;
    public float maxY = 4.6f;

    public float intervalDecreaseRate = 0.1f; // �������ʂ�0.1�ɕύX�I
    public float minSpawnInterval = 1f;       // �ŏ��̏o���Ԋu

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

        // 10�b�o�߂��Ƃ� spawnInterval ��Z������
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
            Debug.LogWarning("Spawner: objectToSpawn �� null �܂��͔j�󂳂�Ă��܂��I");
        }
    }
}