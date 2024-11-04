using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong;
using Scene;

namespace Entity;

public class Ball
{
    Texture2D sprite;
    Vector2 position, direction, colliderOffset;
    Rectangle boxCollider2D;

    Random randomDirection;
    public Ball(Texture2D Sprite, Rectangle Collider)
    {
        sprite = Sprite;
        position = new Vector2(Collider.X, Collider.Y);
        boxCollider2D = Collider;
        colliderOffset = Vector2.Zero;
        randomDirection = new Random();
        direction = new Vector2(
            randomDirection.Next(-1, 2),
            randomDirection.Next(-1, 2)
            );
        if(direction.X == 0)
        {
            direction.X = 1;
        }

    }

    public void Update(GameTime gameTime)
    {
        position += direction * 2;
        boxCollider2D.Location = new Point((int)(position.X + colliderOffset.X), (int)(position.Y + colliderOffset.Y));
        KeepInTheScreen();
        DetectPaddleCollider();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, position, null, Color.White);
        spriteBatch.Draw(sprite, boxCollider2D, Color.Red * 0.3f);
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
        if(boxCollider2D.Left < MainScene.paddle1.GetCollider.Right)
        {
            direction.X = 1;
        }
        if(boxCollider2D.Right > MainScene.paddle2.GetCollider.Left)
        {
            direction.X = -1;
        }
    }
}