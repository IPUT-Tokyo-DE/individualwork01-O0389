using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    // �Q�[���J�n�O�ɕ\������UI�i��: "Press Enter to Start" �Ȃǂ̃��b�Z�[�W�j
    public GameObject startUI;

    void Start()
    {
        // �Q�[���J�n���Ɉꎞ��~���AUI��\��
        Time.timeScale = 0f;  // �Q�[�����~
        startUI.SetActive(true);  // UI��\��
    }

    void Update()
    {
        // �G���^�[�L�[�������ꂽ��Q�[�����J�n
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // �Q�[�����J�n
        Time.timeScale = 1f;  // �Q�[�����ĊJ
        startUI.SetActive(false);  // UI���\���ɂ���
    }
}