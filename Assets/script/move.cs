using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���Ǘ��p

public class DangerObject : MonoBehaviour
{
    public float lifetime = 2f;  // �I�u�W�F�N�g�̎����i������܂ł̎��ԁj

    [Header("�T�C�Y�ݒ�")]
    public Vector2 objectSize = new Vector2(1f, 1f);  // �T�C�Y�ݒ�

    void Start()
    {
        // �T�C�Y�ݒ�
        transform.localScale = new Vector3(objectSize.x, objectSize.y, 1f);
        // ��莞�Ԍ�ɍ폜
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Target�^�O�����I�u�W�F�N�g�ɐG�ꂽ��Q�[�����~
        if (other.CompareTag("Target"))
        {
            Debug.Log("Target���댯�I�u�W�F�N�g�ɐG�ꂽ�I�Q�[����~�I");
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        // �Q�[������~���Ă���ꍇ��R�L�[�������ƃV�[�����ustart�v�Ƀ����[�h
        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("start");  // �V�[���ustart�v�ɑJ��
        }
    }
}