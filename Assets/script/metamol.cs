using UnityEngine;

public class ShapeChanger : MonoBehaviour
{
    public Sprite circleSprite;
    public Sprite squareSprite;
    public Sprite triangleSprite;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = circleSprite; // ������Ԃ�Circle��
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            spriteRenderer.sprite = squareSprite;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            spriteRenderer.sprite = triangleSprite;
        }
        else if (Input.GetKeyDown(KeyCode.C)) // C�L�[��Circle�ɖ߂��i�C�Ӂj
        {
            spriteRenderer.sprite = circleSprite;
        }
    }
}
