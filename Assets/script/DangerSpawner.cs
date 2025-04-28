using UnityEngine;

public class DangerSpawner : MonoBehaviour
{
    public GameObject dangerPrefab;   // ��������I�u�W�F�N�g�̃v���n�u
    public float spawnInterval = 5f;  // �����Ԋu

    [Header("�o���͈�")]
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    public float intervalDecreaseRate = 0.1f; // ���ǉ��F������
    public float minSpawnInterval = 1f;        // ���ǉ��F�ŏ��Ԋu

    private float timer = 0f;
    private float timeElapsed = 0f;             // ���ǉ��F�o�ߎ��ԃJ�E���g�p

    void Update()
    {
        timer += Time.deltaTime;
        timeElapsed += Time.deltaTime; // ���ǉ�

        if (timer >= spawnInterval)
        {
            SpawnDanger();
            timer = 0f;
        }

        // ��10�b���Ƃ�spawnInterval�����炷
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

        // �T�C�Y�������_���ɕύX (X: 1~3, Y: 1~3)
        float randomScaleX = Random.Range(1f, 3f);
        float randomScaleY = Random.Range(1f, 3f);
        newDanger.transform.localScale = new Vector3(randomScaleX, randomScaleY, 1f);
    }
}