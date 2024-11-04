using Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong;

namespace Scene;

public static class MainScene
{
    public static Paddle paddle1;
    public static Paddle paddle2;

    static Ball ball;
    public static void Init()
    {
        SetupPaddle();
        SetupBall();
    }
    public static void Update(GameTime gameTime)
    {
        paddle1.Update(gameTime);
        paddle2.Update(gameTime);
        ball.Update(gameTime);
    }
    public static void Draw(SpriteBatch spriteBatch)
    {
        paddle1.Draw(spriteBatch);
        paddle2.Draw(spriteBatch);
        ball.Draw(spriteBatch);
    }

    private static void SetupPaddle()
    {
        // paddle user no 1
        paddle1 = new Paddle(
            Game1.paddleSprite,
            new Rectangle(50, 50, Game1.paddleSprite.Height, Game1.paddleSprite.Width)
        );
        paddle1.AddMovement(Keys.W, Keys.S);
        paddle1.Rotate(MathHelper.ToRadians(90));
        paddle1.MoveCollider(-20, 0);

        // paddle user no 2
        paddle2 = new Paddle(
            Game1.paddleSprite,
            new Rectangle(Game1.RESOLUTION_WIDTH - 50, 50, Game1.paddleSprite.Height, Game1.paddleSprite.Width)
        );
        paddle2.AddMovement(Keys.Up, Keys.Down);
        paddle2.Rotate(MathHelper.ToRadians(90));
        paddle2.MoveCollider(-30, 0);
    }

    private static void SetupBall()
    {
        ball = new Ball(
            Game1.ballSprite,
            new Rectangle(Game1.RESOLUTION_WIDTH / 2, Game1.RESOLUTION_HEIGHT / 2, Game1.ballSprite.Width, Game1.ballSprite.Height)
        );
    }
}