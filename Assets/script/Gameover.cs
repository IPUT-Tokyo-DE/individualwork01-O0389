using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnCollision : MonoBehaviour
{
    public string resetTag = "ResetTrigger"; // ���������烊�Z�b�g����Ώۂ̃^�O��

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(resetTag))
        {
            Debug.Log("���Z�b�g�g���K�[�ɐڐG�F���Z�b�g���܂�");
            ResetGame();
        }
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // �V�[���������[�h
    }
}