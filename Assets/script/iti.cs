using UnityEngine;

public class LimitXYPosition : MonoBehaviour
{
    public float minX = -8.88f;
    public float maxX = 2.66f;
    public float minY = -4.07f;

    void Update()
    {
        Vector3 pos = transform.position;

        // Xé≤ÇÃêßå¿
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        // Yé≤ÇÃêßå¿Åiâ∫å¿ÇÃÇ›Åj
        if (pos.y < minY)
        {
            pos.y = minY;
        }

        transform.position = pos;
    }
}