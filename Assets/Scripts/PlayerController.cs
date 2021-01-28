using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Shape
{
    public ProjectileController projectileController;

    protected override void Start()
    {
        base.Start();
        SetColor(Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        Moveplayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    private void Moveplayer()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon)
        {
            horizontalMovement *= gameSceneController.playerSpeed * Time.deltaTime;
            horizontalMovement += transform.position.x;
            var right = gameSceneController.screenBounds.x - halfWidth;
            var left = -right;
            var limit = Mathf.Clamp(horizontalMovement, left, right);
            transform.position = new Vector2(limit, transform.position.y);
        }
    }

    private void FireProjectile()
    {
        var spawnPosition = transform.position;
        var projectile = Instantiate(projectileController, spawnPosition, Quaternion.identity);
    }
}
