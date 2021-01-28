using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : Shape, IKillable
{
    public Vector2 projectileDirection = Vector2.up;
    public float projectileSpeed = 2;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Name = "Projectile";
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
            gameSceneController.KillObject(this);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public string GetName()
    {
        return Name;
    }
}
