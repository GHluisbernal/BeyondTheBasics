using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : Shape
{
    public Vector2 projectileDirection = Vector2.up;
    public float projectileSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.Translate(projectileDirection * Time.deltaTime * projectileSpeed, Space.World);
        var top = transform.position.y + halfHeight;
        if (top >= gameSceneController.screenBounds.y)
        {
            Destroy(gameObject);
        }
    }
}
