using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject[] objects; // �؂�ւ��Ώ�
    private int currentIndex = 0;

    void Start()
    {
        UpdateActiveObject();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchTo(currentIndex + 1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchTo(currentIndex - 1);
        }
    }

    void SwitchTo(int newIndex)
    {
        if (objects.Length == 0) return;
        newIndex = (newIndex + objects.Length) % objects.Length;

        GameObject currentObj = objects[currentIndex];
        GameObject nextObj = objects[newIndex];

        // ��Ԃ̈����p��
        Vector3 savedPosition = currentObj.transform.position;
        Quaternion savedRotation = currentObj.transform.rotation;

        Rigidbody2D rbCurrent = currentObj.GetComponent<Rigidbody2D>();
        Vector2 savedVelocity = rbCurrent != null ? rbCurrent.linearVelocity : Vector2.zero;

        // ������ �� �L����
        currentObj.SetActive(false);
        nextObj.SetActive(true);

        // ��Ԃ𔽉f
        nextObj.transform.position = savedPosition;
        nextObj.transform.rotation = savedRotation;

        Rigidbody2D rbNext = nextObj.GetComponent<Rigidbody2D>();
        if (rbNext != null)
        {
            rbNext.linearVelocity = savedVelocity;
        }

        currentIndex = newIndex;
    }

    void UpdateActiveObject()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == currentIndex);
        }
    }
}