using UnityEngine;
using UnityEngine.SceneManagement;  // �V�[���Ǘ��p

public class Ame : MonoBehaviour
{
    public float destroyY = -5f;

    private void Update()
    {
        if (transform.position.y <= destroyY)
        {
            Destroy(gameObject);
        }

        // �Q�[������~���Ă���ꍇ��R�L�[�������ƃV�[�����ustart�v�Ƀ����[�h
        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("start");  // �V�[���ustart�v�ɑJ��
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BouncePad"))
        {
            // BouncePad�^�O�̕��̂ɓ���������Փ˂𖳎�����
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            return;
        }

        if (collision.collider.CompareTag("Target"))
        {
            // Target�ɓ���������Q�[����~
            Time.timeScale = 0f;
            Debug.Log("Game Over!");
        }
    }
}