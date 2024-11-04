using Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong;

namespace Scene;

public static class MainScene
{
    static Paddle paddle1;
    static Paddle paddle2;
    public static void Init()
    {
        SetupPaddle();
    }
    public static void Update(GameTime gameTime)
    {
        paddle1.Update(gameTime);
        paddle2.Update(gameTime);
    }
    public static void Draw(SpriteBatch spriteBatch)
    {
        paddle1.Draw(spriteBatch);
        paddle2.Draw(spriteBatch);
    }

    private static void SetupPaddle()
    {
        // paddle user no 1
        paddle1 = new Paddle(Game1.paddleSprite, new Rectangle(50, 50, Game1.paddleSprite.Height, Game1.paddleSprite.Width));
        paddle1.AddMovement(Keys.W, Keys.S);
        paddle1.Rotate(MathHelper.ToRadians(90));
        paddle1.MoveCollider(-20, 0);
        // paddle user no 2
        paddle2 = new Paddle(Game1.paddleSprite, new Rectangle(Game1.RESOLUTION_WIDTH - 50, 50, Game1.paddleSprite.Height, Game1.paddleSprite.Width));
        paddle2.AddMovement(Keys.Up, Keys.Down);
        paddle2.Rotate(MathHelper.ToRadians(90));
        paddle2.MoveCollider(-30, 0);
    }
}