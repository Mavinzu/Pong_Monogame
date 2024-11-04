using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong;

namespace Entity;

public class Paddle
{
    Texture2D sprite;
    Vector2 position, origin, colliderOffset;
    Rectangle boxCollider2D; // collider
    float rotation; // rotation of sprite
    
    Keys[] movement = new Keys[2]; // input movement

    // Access to rectangle paddle
    public Rectangle GetCollider{
        get{
            return boxCollider2D;
        }
    }
    public Paddle(Texture2D Sprite, Rectangle Collider)
    {
        sprite = Sprite;
        position = new Vector2(Collider.X, Collider.Y);
        boxCollider2D = Collider;
        colliderOffset = Vector2.Zero;
        origin = Vector2.Zero;
    }

    public void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if(keyboardState.IsKeyDown(movement[0]))
        {
            position.Y -= 10f;
        }
        else if(keyboardState.IsKeyDown(movement[1]))
        {
            position.Y += 10f;
        }
        // keep paddle on the screen
        position.Y = MathHelper.Clamp(position.Y, 0, Game1.RESOLUTION_HEIGHT - sprite.Width);
        // update collider location
        boxCollider2D.Location = new Point((int)(position.X + colliderOffset.X), (int)(position.Y + colliderOffset.Y));
        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, position, null, Color.White, rotation, origin, 1, 0, 0);
        spriteBatch.Draw(sprite, boxCollider2D, Color.Red * 0.3f);
    }

    public void AddMovement(Keys up, Keys down)
    {
        movement[0] = up;
        movement[1] = down;
    }
    public void Rotate(float Rot)
    {
        rotation = Rot;
    }
    public void MoveCollider(int xPos, int yPos)
    {
        colliderOffset = new Vector2(xPos, yPos);
    }
}