using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���J�ڂ��g�p���邽�߂ɕK�v

public class StartScreenManager : MonoBehaviour
{
    public GameObject startText;  // �uGame Start�v�ƁuPlease Enter�v��\������UI�I�u�W�F�N�g

    void Start()
    {
        // �ŏ��ɃQ�[�����~���A�X�^�[�g��ʂ̃e�L�X�g��\��
        Time.timeScale = 0f;  // �Q�[�����~
        startText.SetActive(true);  // �e�L�X�g��\��
    }

    void Update()
    {
        // �G���^�[�L�[�������ꂽ��V�[���J��
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // �Q�[�����J�n���āA�X�^�[�g��ʂ��\���ɂ��A�V�[����J��
        Time.timeScale = 1f;  // �Q�[�����ĊJ
        startText.SetActive(false);  // �X�^�[�g��ʂ̃e�L�X�g���\���ɂ���

        // SampleScene�ɑJ��
        SceneManager.LoadScene("SampleScene");
    }
}