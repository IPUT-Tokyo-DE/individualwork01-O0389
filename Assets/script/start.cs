using UnityEngine;

public class StartGameOnEnter : MonoBehaviour
{
    public GameObject titleScreenUI; // �^�C�g����ʂ�UI�iCanvas�Ȃǁj

    private bool hasStarted = false; // ��x�����X�^�[�g���邽�߂̃t���O

    void Start()
    {
        // �Q�[�����~��Ԃ�
        Time.timeScale = 0f;

       
    }

    void Update()
    {
        if (!hasStarted && Input.GetKeyDown(KeyCode.Return)) ; // Enter�L�[�ŊJ�n
        
    }
}