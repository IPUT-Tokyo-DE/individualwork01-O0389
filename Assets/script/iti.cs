using UnityEngine;

public class LimitXYPosition : MonoBehaviour
{
    public float minX = -8.88f;
    public float maxX = 2.66f;
    public float minY = -4.07f;

    void Update()
    {
        Vector3 pos = transform.position;

        // X���̐���
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        // Y���̐����i�����̂݁j
        if (pos.y < minY)
        {
            pos.y = minY;
        }

        transform.position = pos;
    }
}