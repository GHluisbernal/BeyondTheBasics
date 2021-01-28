using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StopController: MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }

}
