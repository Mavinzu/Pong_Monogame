using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong;
using Scene;

namespace Entity;

public class Ball
{
    Texture2D sprite;
    Vector2 position, direction, colliderOffset, spawnPosition;
    Rectangle boxCollider2D;
    float movementSpeed;

    Random randomDirection;
    public Ball(Texture2D Sprite, Rectangle Collider)
    {
        sprite = Sprite;
        position = new Vector2(Collider.X, Collider.Y);
        spawnPosition = position;
        boxCollider2D = Collider;
        colliderOffset = Vector2.Zero;
        movementSpeed = 2;

        // Random direction for the first time
        randomDirection = new Random();
        SpawnBall();

    }

    public void Update(GameTime gameTime)
    {
        position += direction * movementSpeed;
        boxCollider2D.Location = new Point((int)(position.X + colliderOffset.X), (int)(position.Y + colliderOffset.Y));
        GetScore();
        KeepInTheScreen();
        DetectPaddleCollider();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, position, null, Color.White);
    }

    private void KeepInTheScreen()
    {
        if(boxCollider2D.Bottom > Game1.RESOLUTION_HEIGHT)
        {
            direction.Y = -1;
        }
        if(boxCollider2D.Top < 0)
        {
            direction.Y = 1;
        }
    }

    private void DetectPaddleCollider()
    {
        if(boxCollider2D.Intersects(MainScene.paddle1.GetCollider))
        {
            direction.X = 1;
            movementSpeed += 1;

            direction.Y = randomDirection.Next(-1, 2);
        }
        if(boxCollider2D.Intersects(MainScene.paddle2.GetCollider))
        {
            direction.X = -1;
            movementSpeed += 1;

            direction.Y = randomDirection.Next(-1, 2);
        }
    }

    private void SpawnBall()
    {
        direction = new Vector2(
            randomDirection.Next(-1, 2),
            randomDirection.Next(-1, 2)
            );
        if(direction.X == 0)
        {
            direction.X = 1;
        }
        position = spawnPosition;
        movementSpeed = 2;
    }

    private void GetScore()
    {
        if(boxCollider2D.Right > Game1.RESOLUTION_WIDTH)
        {
            MainScene.UpdateScore(ScoreUI.score1);
            SpawnBall();
        }
        if(boxCollider2D.Left < 0)
        {
            MainScene.UpdateScore(ScoreUI.score2);
            SpawnBall();
        }
    }
}