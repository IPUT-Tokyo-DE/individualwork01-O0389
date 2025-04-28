using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // UI��Text���g�����߂ɕK�v

public class PauseOnBulletContact : MonoBehaviour
{
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    public static bool isGameOver = false;
    private float elapsedTime = 0f;

    public Text gameOverText;  // �o�ߎ��Ԃ�\������Text�R���|�[�l���g

    void Start()
    {
        // �Q�[���J�n����Text���\���ɂ��Ă���
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver)
        {
            // �Q�[���I�[�o�[��A�o�ߎ��Ԃ�\�����A�X�y�[�X�L�[�������ƃV�[���J��
            if (gameOverText != null)
            {
                gameOverText.text = $"Game Over\nTime Elapsed: {elapsedTime:F2} seconds";
                gameOverText.gameObject.SetActive(true);  // �o�ߎ��Ԃ̃e�L�X�g��\��
            }

            // �X�y�[�X�L�[�ŃV�[���ustart�v�ɖ߂�
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("start");
            }

            return;
        }

        elapsedTime += Time.deltaTime;  // �o�ߎ��Ԃ����Z

        Vector2 pos = transform.position;

        // �w��͈͊O�ɏo���ꍇ�̏���
        if (pos.x < minX || pos.x > maxX || pos.y < minY || pos.y > maxY)
        {
            Debug.Log($"�w��͈͊O�ɏo�����߁A�o�ߎ���: {elapsedTime:F2}�b");
            GameOver();  // �Q�[���I�[�o�[����
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log($"Bullet�ɐڐG�F�o�ߎ���: {elapsedTime:F2}�b");
            GameOver();  // �Q�[���I�[�o�[����
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;  // �Q�[�����~
        isGameOver = true;    // �Q�[���I�[�o�[��Ԃɂ���
    }
}