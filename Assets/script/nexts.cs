using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // UI�̃e�L�X�g���g������

public class GameOverManager : MonoBehaviour
{
    public Text gameOverText;  // �o�ߎ��Ԃ�\������e�L�X�g
    private float timeElapsed = 0f;  // �o�ߕb��
    private bool isGameOver = false; // �Q�[���I�[�o�[���ǂ���

    void Update()
    {
        // �Q�[���I�[�o�[��Ԃł���Όo�ߎ��Ԃ�\��
        if (isGameOver)
        {
            timeElapsed += Time.deltaTime;

            // �o�ߎ��Ԃ��e�L�X�g�ɕ\��
            gameOverText.text = "Game Over\nTime Elapsed: " + timeElapsed.ToString("F2") + " seconds";

            // R�L�[�������ꂽ��A���݂̃V�[�������Z�b�g
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���݂̃V�[�����ă��[�h
            }
        }
        else
        {
            // �Q�[���I�[�o�[�łȂ���Ԃł̓e�L�X�g���\��
            gameOverText.text = ""; // �Q�[���I�[�o�[�ȊO�ł̓e�L�X�g���N���A
        }
    }

    // �Q�[���I�[�o�[�𔭐������郁�\�b�h
    public void TriggerGameOver()
    {
        // �Q�[���I�[�o�[�𔭐�������
        Time.timeScale = 0f;  // �Q�[����~
        isGameOver = true;  // �Q�[���I�[�o�[��Ԃɂ���
    }

    // ��F�Փˎ��ɃQ�[���I�[�o�[�𔭐�������
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // ��F�G�ɏՓ˂����Ƃ�
        {
            TriggerGameOver();  // �Q�[���I�[�o�[���Ăяo��
        }
    }
}